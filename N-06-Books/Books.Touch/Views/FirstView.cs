using System;
using System.Drawing;
using Book.Core.ViewModels;
using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;

namespace Books.Touch.Views
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("UIViewController1")]
    public class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            //var label = new UILabel(new RectangleF(10,30,300,20));
            //label.Text = "Maria";
            //Add(label);

            var textField = new UITextField(new RectangleF(10, 80, 300, 40));
            textField.BackgroundColor = UIColor.Red;
            Add(textField);

            var tableView = new UITableView(new RectangleF(0,130,320,400), UITableViewStyle.Plain);
            Add(tableView);
            var source =  new MvxStandardTableViewSource(tableView, "TitleText");
            tableView.Source = source;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(textField).To(vm => vm.SearchTerm);
            set.Bind(source).To(vm => vm.Results);
            set.Apply();
            tableView.ReloadData();

            // Perform any additional setup after loading the view
        }
    }
}