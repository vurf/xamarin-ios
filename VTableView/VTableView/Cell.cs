
using System;

using Foundation;
using UIKit;

namespace VTableView
{
	public partial class Cell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("Cell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("Cell");

		public Cell (IntPtr handle) : base (handle)
		{
		}

		public static Cell Create ()
		{
			return (Cell)Nib.Instantiate (null, null) [0];
		}
	}
}

