﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Six.Wx.IRepositoy;
using Six.Wx.Repositoy;
using Autofac.Integration.WebApi;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Six.Wx.Repositoy.Zbs;
using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Repositoy.Fdy;
using Six.Wx.IRepositoy.Fdy;

using Six.Wx.Repositoy.Dq;
using Six.Wx.IRepositoy.Dq;
using Six.Wx.Repositoy.Qxy;
using Six.Wx.IRepositoy.Qxy;

namespace Six.Wx.Api
{
    public static class AutofacConfig
    {
        /// <summary>
        /// 项目初始化，实例化IOC容器
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);

            //注册所有的ApiControllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var container = builder.Build();

            //注册api容器需要使用HttpConfiguration对象
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// 将实现类与接口注入到IOC容器中
        /// </summary>
        /// <param name="builder"></param>
        public static void SetupResolveRules(ContainerBuilder container)
        {
            container.RegisterType<ZappointmentRepository>().As<IZappointmentRepository>();
            container.RegisterType<SappointmentRepository>().As<ISappointmentRepository>();
            container.RegisterType<ZAddressRepository>().As<IZAddressRepository>();
            container.RegisterType<SearchRepository>().As<ISearchRepository>();
            container.RegisterType<AleadyBooksRepository>().As<IAleadyBooksRepository>();
        }
    }
}