
using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace VTableView
{
	public partial class ViewController : UIViewController
	{
		public ViewController () : base ("ViewController", null)
		{
		}
		private List<string> _items = new List<string> {
			"dasdasda",
			"dasdasdadfasdf asdf asd fasd fasd fas dfasd fasd fasd fasd",
			"dasdasda asd fas d",
			"dasdasda a s as a d asd asd fasd fasdfhkasgf dkjhasg kdfags kdgfkasdgf dgs fkdags kfjagsk fjgakjdgfasjdg fkas d",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasdadsfa sdf asdf asdfa jdjhagsgf kajdsgf kjasgd fkjagsd kfja skdjfg kasjdgfjasdg fkas dkfa",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasdadfasdf asdf asd fasd fasd fas dfasd fasd fasd fasd",
			"dasdasda asd fas d",
			"dasdasda a s as a d asd asd fasd fasdfhkasgf dkjhasg kdfags kdgfkasdgf dgs fkdags kfjagsk fjgakjdgfasjdg fkas d",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
			"dasdasda",
		};
		private UITableView table;
		private TableSource source;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillShowNotification, KeyboardWillShow); 
			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillHideNotification, KeyboardWillHide);

			table = new UITableView (new CGRect(0, 20, View.Bounds.Width, View.Bounds.Height));
			source = new TableSource (_items);
			table.Source = source;
			table.EstimatedRowHeight = 44f;
			table.RowHeight = UITableView.AutomaticDimension;
			table.KeyboardDismissMode = UIScrollViewKeyboardDismissMode.OnDrag;
			View.AddSubview (table);


		}

		private void KeyboardWillShow(NSNotification n)
		{
			var keyboardSize = UIKeyboard.FrameEndFromNotification (n);
			table.ContentInset = new UIEdgeInsets (0, 0, keyboardSize.Height + 20, 0);
		}

		private void KeyboardWillHide(NSNotification n)
		{
			table.ContentInset = UIEdgeInsets.Zero;
		}
	}
}

