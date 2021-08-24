using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomBrowser
{
	public partial class MainForm : Form
	{
		private List<RomItem> _romList;
		private string _path;
		private string[] _pattern;
		private RomInfo[] _romInfo;
		private int _romInfoCount;
		private int _activeRomInfo;

		public MainForm()
		{
			InitializeComponent();

			//CreateTestBin();

			this.Text = Helper.GetVersion();

			DirectoryListView.View = View.Details;
			DirectoryListView.HeaderStyle = ColumnHeaderStyle.None;
			DirectoryListView.Columns[1].TextAlign = HorizontalAlignment.Right;
			DirectoryListView.FullRowSelect = true;
			DirectoryListView.SelectedIndexChanged += DirectoryListView_SelectedIndexChanged;

			_romInfoCount = 2;
			_activeRomInfo = 0;
			RomCountCb.DataSource = new int[] { 1, 2, 3, 4 }; // 1..4 rom images
			RomCountCb.SelectedIndex = 1; // show 2 images

			InitRomInfo();
			ShowRomInfo();

#if DEBUG
			_path = @"d:\daten\MiniPro\Daten";
#else
			_path = Directory.GetCurrentDirectory();
#endif

			ChangeDirBtn.Text = _path;
			_pattern = new string[] { "*.bin", "*.rom", "*.prg", "*.hex" };
			PatternTb.Text = PatternListToStr(_pattern);

			UpdateDirectory();
		}

		private void InitRomInfo()
		{
			int x0 = 396;
			int y0 = 33;
			int width = 413;
			int height = 220;

			_romInfo = new RomInfo[4];
			int index = 0;
			for (int x = 0; x < 2; x++)
			{
				for (int y = 0; y < 2; y++)
				{
					RomInfo romInfo = new RomInfo()
					{
						Index = index,
						Width = width,
						Height = height,
						Left = x0 + x * width,
						Top = y0 + y * height,
						//BorderStyle = BorderStyle.FixedSingle,
					};
					romInfo.ClickEvent += RomInfo_ClickEvent;
					romInfo.CompareChangedEvent += RomInfo_CompareChangedEvent;
					_romInfo[index] = romInfo;
					index++;
				}
			}
		}

		private void RomCountCb_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			//int selectedIndex = cmb.SelectedIndex;
			_activeRomInfo = 0;
			SetActiveRomInfo(_activeRomInfo);
			_romInfoCount = (int)cmb.SelectedValue;
			ShowRomInfo();
		}

		private void RomInfo_ClickEvent(RomInfo romInfo)
		{
			SetActiveRomInfo(romInfo.Index);
		}

		private void RomInfo_CompareChangedEvent()
		{
			// reset all compare images
			for (int i = 0; i < 4; i++)
			{
				_romInfo[i].CompareImage = null;
				Task task = _romInfo[i].ShowInfo();
			}

			// extract roms for compare
			List<RomInfo> romInfoCmp = new List<RomInfo>();
			for (int i = 0; i < _romInfoCount; i++)
			{
				if (_romInfo[i].Compare) romInfoCmp.Add(_romInfo[i]);
			}

			if (romInfoCmp.Count < 2)
			{
				// compare not active
				return;
			}

			// get largest rom size
			int maxSize = 0;
			for (int i = 0; i < romInfoCmp.Count; i++)
			{
				if (_romInfo[i].RomItem.Size > maxSize) maxSize = _romInfo[i].RomItem.Size;
			}

			byte[] compareImage = new byte[maxSize];
			for (int b = 0; b < maxSize; b++)
			{
				compareImage[b] = 0; // default is no difference
				byte? data = null;
				for (int i = 0; i < romInfoCmp.Count; i++)
				{
					if (b >= romInfoCmp[i].RomImage.Length)
					{   // skip bytes that are out of size and mark as difference
						compareImage[b] = 1; // difference
						break;
					}
					if (data == null)
					{
						data = romInfoCmp[i].RomImage[b];
						continue;
					}
					if (romInfoCmp[i].RomImage[b] != data)
					{
						compareImage[b] = 1; // difference
						break;
					}
				}
			}

			SetCompareImage(compareImage);
		}

		private void SetCompareImage(byte[] compareImage)
		{
			for (int i = 0; i < _romInfoCount; i++)
			{
				if (_romInfo[i].Compare)
				{
					_romInfo[i].CompareImage = compareImage;
					Task task = _romInfo[i].ShowInfo();
				}
			}
		}

		private void ShowRomInfo()
		{
			if (_romInfoCount <= 2)
			{
				this.Width = 834;
			}
			else
			{
				this.Width = 1250;
			}

			if (_romInfo == null) return;

			for (int i = 0; i < 4; i++)
			{
				this.Controls.Remove(_romInfo[i]);
			}

			for (int i = 0; i < _romInfoCount; i++)
			{
				this.Controls.Add(_romInfo[i]);
			}
		}

		private void SetActiveRomInfo(int index)
		{
			_activeRomInfo = index;
			if (_romInfo == null) return;

			for (int i = 0; i < 4; i++)
			{
				_romInfo[i].Active = (i==_activeRomInfo);
				_romInfo[i].Refresh();
			}
		}

		private void ChangeDirBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = _path;
			DialogResult result = fbd.ShowDialog();
			if (result == DialogResult.OK)
			{
				_path = fbd.SelectedPath;
				ChangeDirBtn.Text = _path;
				UpdateDirectory();
			}
		}

		private void DirRefreshBtn_Click(object sender, EventArgs e)
		{
			UpdateDirectory();
		}

		private void PatternTb_Leave(object sender, EventArgs e)
		{
			_pattern = PatternStrToList(PatternTb.Text);
			UpdateDirectory();
		}

		private async void DirectoryListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedItems = ((ListView)sender).SelectedItems;
			if (selectedItems == null || selectedItems.Count == 0) return;
			RomItem romItem = (RomItem)selectedItems[0].Tag;

			byte[] romImg = LoadFile(romItem.FullName);

			RomInfo romInfo = _romInfo[_activeRomInfo];
			await romInfo.ShowInfo(romItem, romImg);

			for (int i=0; i<_romInfoCount; i++)
			{
				if (_romInfo[i].Compare)
				{
					RomInfo_CompareChangedEvent();
					break;
				}
			}
		}

		private byte[] LoadFile(string fullName)
		{
			byte[] romImg;
			try
			{
				string ext = Path.GetExtension(fullName).ToLower();
				if (ext == ".hex")
				{
					string[] hexLines = File.ReadAllLines(fullName);
					IntelHexConv conv = new IntelHexConv();
					romImg = conv.HexToBin(hexLines, 0, 0, out _);
				}
				else
				{
					romImg = File.ReadAllBytes(fullName);
				}
				return romImg;
			}
			catch
			{
				return null;
			}
		}

		private void UpdateDirectory()
		{
			_romList = LoadRomList(_path, _pattern);
			_romList.Sort(new RomItemComparerName());
			ShowRomList(_romList);
		}

		private string[] PatternStrToList(string pattern)
		{
			string[] patternList = pattern.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i=0; i<_pattern.Length; i++)
			{
				_pattern[i] = _pattern[i].Trim();
			}
			return patternList;
		}

		private string PatternListToStr(string[] patternList)
		{
			return string.Join(",", patternList);
		}

		private List<RomItem> LoadRomList(string path, string[] pattern)
		{
			List<RomItem> romList = new List<RomItem>();
			foreach (string pat in pattern)
			{
				romList.AddRange(LoadRomListPattern(path, pat));
			}
			return romList;
		}

		private List<RomItem> LoadRomListPattern(string path, string pattern)
		{
			List<RomItem> romList = new List<RomItem>();
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			FileInfo[] files = dirInfo.GetFiles(pattern);

			foreach (FileInfo fileInfo in files)
			{
				RomItem romItem = new RomItem()
				{
					Name = fileInfo.Name,
					FullName = fileInfo.FullName,
					Size = (int)fileInfo.Length,
					Timestamp = fileInfo.LastWriteTime,
				};
				romList.Add(romItem);
			}
			return romList;
		}

		private void ShowRomList(List<RomItem> romList)
		{
			DirectoryListView.Items.Clear();
			foreach(RomItem romItem in romList)
			{
				ListViewItem item = new ListViewItem(new string[] {
					romItem.Name,
					romItem.Size.ToString(),
					romItem.Timestamp.ToString("dd.MM.yy HH:mm")
				});
				item.Tag = romItem;
				DirectoryListView.Items.Add(item);
			}
		}

		private void CreateTestBin()
		{
			int size = 8192 * 2;
			byte[] image = new byte[size];
			for (int i=0; i< size; i++)
			{
				image[i] = (byte)(i % 256);
			}
			File.WriteAllBytes($@"d:\daten\MiniPro\Daten\romwizard{size}.bin", image);
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e)
		{
			Debug.WriteLine($"{Width} {Height}");
		}
	}
}
