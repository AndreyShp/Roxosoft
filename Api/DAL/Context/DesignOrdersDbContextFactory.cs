using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Roxosoft.Orders.Api.DAL.Context {
    /// <summary>
    /// Фабрика сообщает как создать контекст для работы с базой. Нужно для миграций
    /// <see cref="https://docs.microsoft.com/ru-ru/ef/core/miscellaneous/cli/dbcontext-creation" />
    /// </summary>
    public class DesignOrdersDbContextFactory : IDesignTimeDbContextFactory<OrdersDbContext> {
        public OrdersDbContext CreateDbContext(string[] args) {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var repositoryFactory = RepositoryContextFactory.Create(config);

            return repositoryFactory.CreateDbContext();
        }
    }
}