﻿using Autofac;
using Coolector.Core.IoC.Modules;

namespace Coolector.Core.IoC
{
    public class ModuleContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DispatcherModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<Auth0Module>();
        }
    }
}