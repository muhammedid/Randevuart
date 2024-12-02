using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DIResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<BusinessDal>().As<IBusinessDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As< IAuthService >().SingleInstance();

        }
    }
}
