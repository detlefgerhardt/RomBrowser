using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomBrowser
{
	static class Helper
	{
		public static string GetVersion()
		{
#if DEBUG
			// show date and time in debug version
			string buildTime = Properties.Resources.BuildDate.Trim(new char[] { '\n', '\r' }) + " Debug";
			//string buildTime = ConfigurationManager.AppSettings.Get("builddate") + " Debug";
#else
			// show only date in release version
			string buildTime = Properties.Resources.BuildDate.Trim(new char[] { '\n', '\r' });
			buildTime = buildTime.Substring(0, 10);
#endif
			return $"{Constants.PROGRAM_NAME}  V{Application.ProductVersion}  (Build={buildTime})";
		}

		/// <summary>
		/// Helper method to determin if invoke required, if so will rerun method on correct thread.
		/// if not do nothing.
		/// </summary>
		/// <param name="c">Control that might require invoking</param>
		/// <param name="a">action to preform on control thread if so.</param>
		/// <returns>true if invoke required</returns>
		public static void ControlInvokeRequired(Control c, Action a)
		{
			if (c.InvokeRequired)
			{
				c.Invoke(new MethodInvoker(delegate { a(); }));
			}
			else
			{
				a();
			}
		}
	}
}
