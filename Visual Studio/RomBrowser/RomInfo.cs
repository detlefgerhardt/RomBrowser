using Force.Crc32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomBrowser
{
	public partial class RomInfo : UserControl
	{
		public delegate void ClickEventHandler(RomInfo romInfo);
		public event ClickEventHandler ClickEvent;

		public delegate void ConmpareChangedEventHandler();
		public event ConmpareChangedEventHandler CompareChangedEvent;

		private Bitmap _romBitmap;
		private Color _borderColor = Color.Red;
		private bool _stopShow = false;

		public RomItem RomItem { get; set; }

		public byte[] RomImage { get; set; }

		private bool _active;
		public bool Active
		{
			get
			{
				return _active;
			}
			set
			{
				_active = value;
				if (_active)
				{
					_borderColor = Color.Red;
				}
				else
				{
					_borderColor = SystemColors.Control;
				}
				RomInfoGb.Refresh();
			}
		}

		private int _index;
		public int Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
				RomInfoGb.Text = $"ROM #{_index + 1}";
			}
		}

		public bool Compare { get; private set; }

		private byte[] _compareImage;
		public byte[] CompareImage
		{
			set
			{
				_compareImage = value;
			}
		}

		public RomInfo()
		{
			InitializeComponent();

			int bmpSx = 32 * 3 + 1;
			int bmpSy = 64 * 3 + 1;
			RomImagePb.Width = bmpSx;
			RomImagePb.Height = bmpSy;

			FileNameTb.BackColor = SystemColors.ControlLightLight;
			SizeTb.BackColor = SystemColors.ControlLightLight;
			ChksumTb.BackColor = SystemColors.ControlLightLight;
			Sha1Tb.BackColor = SystemColors.ControlLightLight;
			Sha1Tb.Text = "";

			_romBitmap = new Bitmap(bmpSx * 32, bmpSy * 64);
			RomImagePb.Image = _romBitmap;

			Active = false;

			Compare = false;
			CompareCb.Checked = false;

			RomInfoGb.Click += RomInfoGb_Click;
			RomInfoGb.Paint += RomInfoGb_Paint;
		}

		private void RomInfoGb_Click(object sender, EventArgs e)
		{
			ClickEvent?.Invoke(this);
		}

		public async Task ShowInfo()
		{
			_stopShow = true;
			await ShowRomInfo2(null);
		}

		public async Task ShowInfo(RomItem romItem, byte[] romImage)
		{
			if (romItem == null) return;

			RomItem = romItem;
			RomImage = romImage;
			await ShowRomInfo2(null);
		}

		private async void StartAddrCb_Click(object sender, EventArgs e)
		{
			await ShowRomInfo2(StartAddrCb.Checked);
		}

		private async Task ShowRomInfo2(bool? useStartAddr)
		{
			if (RomItem == null) return;

			FileNameTb.Text = RomItem.Name;

			byte[] romImage = ChkStartAddr(RomImage, useStartAddr, out int? startAddr);
			if (startAddr.HasValue)
			{
				StartAddrTb.Text = $"{startAddr:X04}h";
				SizeTb.Text = $"{romImage.Length} + 2";
				StartAddrCb.Checked = true;
			}
			else
			{
				StartAddrTb.Text = "";
				SizeTb.Text = $"{romImage.Length}";
				StartAddrCb.Checked = false;
			}

			ChksumTb.Text = GetChksum8(romImage);
			Crc32Tb.Text = GetCrc32(romImage);
			Sha1Tb.Text = GetSha1(romImage);

			CheckSignatures(romImage);

			await ShowRomImage(RomImage);
		}

		private void CheckSignatures(byte[] romImage)
		{
			int? ibmExtSize = CheckIbmExtensionRom(romImage);
			if (ibmExtSize.HasValue)
			{
				SignatureTb.Text = $"IBM BIOS Extension size={ibmExtSize:X02}h";
				return;
			}

			SignatureTb.Text = "";
		}

		private async Task ShowRomImage(byte[] romImage)
		{
			_stopShow = true;

			await Task.Run(() =>
			{
				Debug.WriteLine($"{RomItem.Name} {_compareImage!=null}");

				_stopShow = false;

				lock (_romBitmap)
				{
					Graphics g = Graphics.FromImage(_romBitmap);
					g.Clear(Color.Black);

					int psx = 2;
					int psy = 2;

					int romSize = romImage.Length;
					int xs, ys, dn;
					if (romSize > 1024 * 1024)
					{
						RomImagePb.Refresh();
						return;
					}
					if (romSize > 2048)
					{
						xs = 32;
						ys = 64;
						dn = romSize / (xs * ys);
					}
					else
					{
						xs = 32;
						ys = romSize / xs;
						dn = 1;
					}

					for (int y = 0; y < ys; y++)
					{
						for (int x = 0; x < xs; x++)
						{
							int addr = (y * xs + x) * dn;
							Color color = GetColor(romImage, addr, dn);
							int pxa = x * 3 + 1;
							int pya = y * 3 + 1;
							for (int py = 0; py < psy; py++)
							{
								for (int px = 0; px < psx; px++)
								{
									_romBitmap.SetPixel(pxa + px, pya + py, color);
								}
								if (_stopShow) return;
							}
						}
					}

					Helper.ControlInvokeRequired(RomImagePb, () =>
					{
						RomImagePb.Refresh();
					});
				}
			});
		}

		private Color GetColor(byte[] romImage, int addr, int dx)
		{
			int cnt0 = 0;
			int cntFF = 0;
			for (int i = 0; i < dx; i++)
			{
				int a = addr + i;
				if (_compareImage != null && a < _compareImage.Length && _compareImage[a] != 0) return Color.Yellow;
				byte data = romImage[a];
				if (data == 0) cnt0++;
				if (data == 0xFF) cntFF++;
			}

			if (cnt0 > 0 && cnt0 >= cntFF) return Color.Red;
			if (cntFF > 0) return Color.Blue;
			return Color.Green;
		}

		private string GetChksum8(byte[] romImg)
		{
			int chksum = CalcChksum8(romImg);
			return $"{chksum:X2}h";
		}

		private int CalcChksum8(byte[] romImg)
		{
			int chksum = 0;
			foreach (byte b in romImg)
			{
				chksum += b;
			}
			return chksum % 256;
		}

		private string GetCrc32(byte[] romImg)
		{
			int crc32 = CalcCrc32(romImg);
			return $"{crc32:X04}h";
		}

		private int CalcCrc32(byte[] romImg)
		{
			return (int)Crc32Algorithm.Compute(romImg);
		}

		private string GetSha1(byte[] romImg)
		{
			using (SHA1Managed sha1 = new SHA1Managed())
			{
				var hash = sha1.ComputeHash(romImg);
				var sb = new StringBuilder(hash.Length * 2);

				foreach (byte b in hash)
				{
					sb.Append(b.ToString("x2"));
				}
				return sb.ToString();
			}
		}

		private byte[] ChkStartAddr(byte[] romImg, bool? useStartAddr, out int? startAddr)
		{
			startAddr = null;
			if (romImg == null || romImg.Length < 2) return romImg;

			if (useStartAddr.HasValue && !useStartAddr.Value) return romImg;

			double ln = Math.Log(romImg.Length - 2, 2);
			if (useStartAddr.HasValue && useStartAddr.Value || ln - Math.Truncate(ln) == 0)
			{
				startAddr = romImg[0] + romImg[1] * 256;
				byte[] newRomImg = new byte[romImg.Length - 2];
				Buffer.BlockCopy(romImg, 2, newRomImg, 0, romImg.Length - 2);
				return newRomImg;
			}

			return romImg;
		}

		private int? CheckIbmExtensionRom(byte[] romImg)
		{
			if (romImg == null || romImg.Length < 3) return null;
			if (CalcChksum8(romImg) != 0) return null;

			if (romImg[0] == 0x55 && romImg[1] == 0xAA) return romImg[2] * 512;
			return null;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Pen pen = new Pen(_borderColor, 1);
			e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
		}

		private void RomInfoGb_Paint(object sender, PaintEventArgs e)
		{
			return;
		}

		private void RomInfo_Resize(object sender, EventArgs e)
		{
			RomInfoGb.Top = 1;
			RomInfoGb.Left = 1;
			RomInfoGb.Width = this.Width - 2;
			RomInfoGb.Height = this.Height - 2;
		}

		private void CompareCb_Click(object sender, EventArgs e)
		{
			if (CompareCb.Checked != Compare)
			{
				Compare = CompareCb.Checked;
				CompareChangedEvent?.Invoke();
			}
		}
	}
}
