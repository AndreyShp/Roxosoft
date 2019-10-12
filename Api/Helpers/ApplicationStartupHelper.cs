using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roxosoft.Orders.Api.DAL.Context;
using Roxosoft.Orders.Api.DAL.Context.Contracts;
using Roxosoft.Orders.Api.DAL.Repositories;
using Roxosoft.Orders.Api.DAL.Repositories.Contracts;
using Roxosoft.Orders.Api.Managers;
using Roxosoft.Orders.Api.Managers.Contracts;
using Roxosoft.Orders.Api.Mapper;

namespace Roxosoft.Orders.Api.Helpers {
    /// <summary>
    /// Подготовительные действия для запуска приложения
    /// </summary>
    public static class ApplicationStartupHelper {
        /// <summary>
        /// Внедрение зависимостей приложения
        /// </summary>
        /// <param name="services">описание сервисов</param>
        /// <param name="configuration">настройки</param>
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration) {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton(opt => RepositoryContextFactory.Create(configuration));
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersManager, OrdersManager>();
        }
        
        /// <summary>
        /// Накатывает миграцию на базу данных
        /// </summary>
        /// <param name="app">пайплайн приложения</param>
        public static void DatabaseMigrate(IApplicationBuilder app) {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var factory = serviceScope.ServiceProvider.GetService<IRepositoryContextFactory>();
                var context = factory.CreateDbContext();
                context.Database.Migrate();
            }
        }
    }
}