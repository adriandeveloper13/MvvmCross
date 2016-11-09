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
using Book.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace Books.Droid
{
    public class Setup: MvxAndroidSetup
    {
        //comment
        public Setup(Context applicationContext):base(applicationContext)
        { }
        protected override IMvxApplication CreateApp()
        {
            return new Book.Core.App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            InitDependencyInjection();
        }

        private void InitDependencyInjection()
        {
            Mvx.LazyConstructAndRegisterSingleton<IBooksService>( () => new BooksService(Mvx.Resolve<ISimpleRestService>()) );
            Mvx.LazyConstructAndRegisterSingleton<ISimpleRestService>(() => new SimpleRestService(Mvx.Resolve<IMvxJsonConverter>()));
        }
    }
}