using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Mvc.Configurations
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CleanArch.Application.AutoMapper.AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
