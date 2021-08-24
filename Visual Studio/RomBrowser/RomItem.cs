using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomBrowser
{
	public class RomItem
	{
		public string Name { get; set; }

		public string FullName { get; set; }

		public int Size { get; set; }

		public DateTime Timestamp { get; set; }

		public int SelectedIndex { get; set; }

		public override string ToString()
		{
			return $"{Name} {Size} {Timestamp} {SelectedIndex}";
		}
	}

	class RomItemComparerName : IComparer<RomItem>
	{
		/// <summary>
		/// Sort by name ascending
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(RomItem x, RomItem y)
		{
			return string.Compare(x.Name, y.Name);
		}
	}

}
