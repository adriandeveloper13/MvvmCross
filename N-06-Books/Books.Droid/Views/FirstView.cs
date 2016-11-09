using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Book.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace Books.Droid.Views
{
    [Activity(Label = "FirstView")]
    public class FirstView: MvxActivity
    {
        public new FirstViewModel ViewModel
        {
            get { return (FirstViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.FirstView);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


        }
    }
}