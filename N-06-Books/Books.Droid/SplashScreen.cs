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
using MvvmCross.Droid.Views;

namespace Books.Droid
{
    [Activity(Label="Book App", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen: MvxSplashScreenActivity
    {
        public SplashScreen():base(Resource.Layout.SplashScreen){}
    }
}