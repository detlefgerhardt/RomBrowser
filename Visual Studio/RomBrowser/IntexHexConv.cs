using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RomBrowser
{
	public class IntelHexConv
	{
		private List<Segment> _segments;

		public int ErrLineNr { get; set; }

		public string ErrLineStr { get; set; }

		/// <summary>
		/// Wandelt einen Byte-Buffer in 16-Bit Intelhex-Format
		/// </summary>
		/// <param name="buffer">Byte-Buffer</param>
		/// <param name="offset">Startadresse</param>
		/// <param name="bytesPerLine"></param>
		/// <returns></returns>
		public void BinToHex(string srcName, string dstName, int offset, int bytesPerLine, bool prgMode, out string msg)
		{
			msg = "";
			byte[] buffer;
			try
			{
				buffer = File.ReadAllBytes(srcName);
			}
			catch(Exception)
			{
				msg = $"Error reading '{srcName}'";
				return;
			}

			int addr = BitConverter.ToUInt16(buffer, 0);
			if (prgMode)
			{
				Console.WriteLine($"prg-addr: ${addr:X4} ({addr})");
				if (offset != addr)
				{   // inconsistent prgMode and offset
					msg = $"Error: inconsistent prgaddr and offset";
					return;
				}
			}

			List<string> lines = new List<string>();
			int pos = 0;
			while (pos < buffer.Length - 1)
			{
				lines.Add(LineToHex(buffer, pos, offset, bytesPerLine));
				pos += bytesPerLine;
				offset += bytesPerLine;
			}
			lines.Add(":00000001FF");

			try
			{
				File.Delete(dstName);
				File.WriteAllLines(dstName, lines);
			}
			catch (Exception)
			{
				msg = $"Error writing '{dstName}'";
			}

			msg = $"Write '{dstName}'";
		}

		private string LineToHex(byte[] buffer, int pos, int addr, int size)
		{
			if (pos + size > buffer.Length)
				size = buffer.Length - pos;

			int checksum = size + (addr & 0xFF) + (addr >> 8);
			string line = $":{size:X2}{addr:X4}00";
			for (int i = 0; i < size; i++)
			{
				line += $"{buffer[pos + i]:X2}";
				checksum += buffer[pos + i];
			}
			checksum %= 256;
			if (checksum > 0)
				checksum = 256 - checksum;
			line += $"{checksum:X2}";
			return line;
		}

		public byte[] HexToBin(string[] lines, int offset, int size, out string msg)
		{
			_segments = new List<Segment>();
			Segment currentSegment = AddSegment(0);

			msg = "";
			ErrLineNr = 0;
			foreach (string line in lines)
			{
				ErrLineNr++;
				ErrLineStr = line;
				if (line.Length < 11)
				{
					msg = $"line to short in {ErrLineNr}";
					return null;
				}
				if (line[0] != ':')
				{
					msg = $"Error: missing ':' in {ErrLineNr}";
					return null;
				}
				int? n = GetHexVal(line.Substring(1, 2));
				if (n == null || line.Length != n * 2 + 11)
				{
					msg = $"Error: wrong line length in {ErrLineNr}";
					return null;
				}
				int? addr = GetHexVal(line.Substring(3, 4));
				if (addr == null)
				{
					msg = $"Error: invalid address in {ErrLineNr}";
					return null;
				}

				int? recType = GetHexVal(line.Substring(7, 2));
				if (recType == null)
				{
					msg = $"Error: invalid record type in {ErrLineNr}";
					return null;
				}
				int? chk = GetHexVal(line.Substring(line.Length - 2, 2));
				if (chk == null)
				{
					msg = $"Error: invalid chksum in {ErrLineNr}";
					return null;
				}
				int chksum = n.Value + (addr.Value >> 8) + (addr.Value & 0xFF) + recType.Value;

				if (recType == 2)
				{
					// new segment
					//:02 0000 02 1000EC
					int? segmAddr = GetHexVal(line.Substring(9, 4));
					if (segmAddr==null)
					{
						msg = $"Error: invalid segment address in {ErrLineNr}";
						return null;
					}
					Debug.WriteLine((segmAddr.Value >> 8) + (segmAddr.Value & 0xFF));
					chksum = CalcChecksum(chksum + (segmAddr.Value & 0xFF) + (segmAddr.Value >> 8));
					Debug.WriteLine($"segmAddr={segmAddr}");
					if (chksum != chk)
					{
						msg = $"Error: chksum mismatch in {ErrLineNr}";
						return null;
					}
					currentSegment = AddSegment(segmAddr.Value);
					continue;
				}

				for (int i = 0; i < n; i++)
				{
					if (addr + i >= 0x10000)
					{
						msg = $"Error: invalid address in {ErrLineNr}";
						return null;
					}
					int? val = GetHexVal(line.Substring(9 + i * 2, 2));
					if (val == null)
					{
						msg = $"Error: invalid hex character in {ErrLineNr}";
						return null;
					}
					currentSegment.SetByte(addr.Value + i, val.Value);
					//buffer[addr.Value + i] = (byte)val.Value;
					chksum += val.Value;
				}
				chksum = CalcChecksum(chksum);
				if (chksum != chk)
				{
					msg = $"Error: chksum mismatch in {ErrLineNr}";
					return null;
				}

				Debug.WriteLine($"{addr:X04}");
			}

			int maxSegmAddr = _segments.Max(s => s.Address);
			Segment maxSegm = (from s in _segments where s.Address == maxSegmAddr select s).FirstOrDefault();
			int maxSize = (maxSegmAddr + 0x1000) * 16;

			byte[] buffer = new byte[maxSize];
			foreach(Segment segm in _segments)
			{
				Buffer.BlockCopy(segm.Buffer, 0, buffer, segm.Address*16, 0x10000);
			}
			if (size==0)
			{
				size = maxSegmAddr * 16 + maxSegm.LastAddress;
			}

			byte[] saveBuffer = new byte[size - offset];
			Buffer.BlockCopy(buffer, 0, saveBuffer, offset, size - offset);

			return saveBuffer;
		}

		private int? GetHexVal(string hex)
		{
			int val;
			if (int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
				return val;
			else
				return null;
		}

		private Segment AddSegment(int address)
		{
			Segment segment = (from s in _segments where s.Address == address select s).FirstOrDefault();
			if (segment==null)
			{
				segment = new Segment(address);
				_segments.Add(segment);
			}
			return segment;
		}

		private int CalcChecksum(int checksum)
		{
			checksum %= 256;
			if (checksum > 0)
			{
				checksum = 256 - checksum;
			}
			return checksum;
		}
	}

	class Segment
	{
		public int Address;

		public int LastAddress;

		public byte[] Buffer;

		public Segment(int address)
		{
			Address = address;
			LastAddress = 0;
			Buffer = new byte[0x10000];
			for (int i = 0; i < 0x10000; i++)
			{
				Buffer[i] = 0x00;
			}
		}

		public void SetByte(int address, int value)
		{
			Buffer[address] = (byte)value;
			LastAddress = address;
		}

		public override string ToString()
		{
			return $"{Address} {LastAddress}";
		}
	}
}
