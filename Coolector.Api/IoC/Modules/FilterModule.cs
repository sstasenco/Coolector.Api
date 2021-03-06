﻿using System.Reflection;
using Autofac;
using Coolector.Api.Filters;
using Coolector.Common.Types;
using Module = Autofac.Module;

namespace Coolector.Api.IoC.Modules
{
    public class FilterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FilterResolver>().As<IFilterResolver>();
            var assembly = typeof(Startup).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IFilter<,>));
        }
    }
}