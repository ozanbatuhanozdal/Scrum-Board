using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.BusinessLayer.Managers;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Repositories;

namespace TestApplication.BusinessLayer.DependencyResolvers
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IManagerBase<>), typeof(ManagerBase<>));

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();

            services.AddScoped<ICustomerCardManager, CustomerCardManager>();
            services.AddScoped<ICustomerCardRepository, CustomerCardRepository>();

            services.AddScoped<ICustomerCardRowManager, CustomerCardRowManager>();
            services.AddScoped<ICustomerCardRowRepository, CustomerCardRowRepository>();

            services.AddScoped<IUserTypeManager, UserTypeManager>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

            services.AddScoped<IJwtManager, JwtManager>();


        }

    }
}
