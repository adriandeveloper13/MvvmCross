using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace Book.Core
{
    public class App :  MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Services")
                .AsInterfaces()
            .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }
}
