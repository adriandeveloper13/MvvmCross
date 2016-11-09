using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Book.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace Books.Touch
{
    public class Setup  : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicatioDelegate, IMvxIosViewPresenter presenter) : base(applicatioDelegate, presenter)
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
            Mvx.LazyConstructAndRegisterSingleton<IBooksService>(() => new BooksService(Mvx.Resolve<ISimpleRestService>()));
            Mvx.LazyConstructAndRegisterSingleton<ISimpleRestService>(() => new SimpleRestService(Mvx.Resolve<IMvxJsonConverter>()));
        }
    }
}