using System;

using Foundation;
using UIKit;

namespace Books.Touch.Views
{
    public partial class BookCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("BookCell");
        public static readonly UINib Nib;

        static BookCell()
        {
            Nib = UINib.FromName("BookCell", NSBundle.MainBundle);
        }

        protected BookCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
