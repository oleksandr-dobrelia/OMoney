﻿using System.Reflection;
using Ninject;
using Ninject.Modules;
using OMoney.Data.Categories;
using OMoney.Data.CatItems;
using OMoney.Data.Plans;
using OMoney.Data.Users;
using OMoney.Domain.Services.Categories;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Plans;
using OMoney.Domain.Services.Users;

namespace OMoney.Web.Api
{
    public class NinjectWebCommon
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IAccountService>().To<AccountService>();
            Bind<IAccountRepository>().To<AccountRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<INotificationService>().To<NotificationService>();
            Bind<IPlanService>().To<PlanService>();
            Bind<IPlanRepository>().To<PlanRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICatItemRepository>().To<CatItemRepository>();
        }
    }
}