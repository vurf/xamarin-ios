using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;

namespace VTableView
{
	public class TableSource : UITableViewSource
	{
		List<string> Items;
		public TableSource (List<string> _items)
		{
			Items = _items;
		}


		#region implemented abstract members of UITableViewSource
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.CellAt (indexPath) as Cell ?? Cell.Create ();
			cell.TextView.Text = Items [indexPath.Row];

			cell.TextView.Changed += (sender, e) => {
				OnChange (tableView, indexPath);
			};

			cell.TextView.Started += (sender, e) => {
				tableView.ScrollToRow (indexPath, UITableViewScrollPosition.Top, true);
			};


			cell.NeedsUpdateConstraints ();
			cell.UpdateConstraintsIfNeeded ();
			return cell;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return Items.Count;
		}
		#endregion

		private void OnChange(UITableView table, NSIndexPath ip)
		{
			var cell = table.CellAt (ip) as Cell;
			var size = cell.TextView.Bounds.Size;
			var newSize = cell.TextView.SizeThatFits (new CGSize (size.Width, nfloat.MaxValue));

			if (size.Height != newSize.Height) {
				UIView.AnimationsEnabled = false;
				table.BeginUpdates ();
				table.EndUpdates ();
				UIView.AnimationsEnabled = true;

				table.ScrollToRow (ip, UITableViewScrollPosition.Top, false);
			}
			Items [ip.Row] = cell.TextView.Text;
		}
	}
}

