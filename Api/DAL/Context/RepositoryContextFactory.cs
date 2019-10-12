using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Roxosoft.Orders.Api.DAL.Context.Contracts;

namespace Roxosoft.Orders.Api.DAL.Context {
    /// <summary>
    /// Фабрика создания контекста для работы с базой
    /// </summary>
    public class RepositoryContextFactory : IRepositoryContextFactory {
        private readonly string _connectionString;

        public RepositoryContextFactory(string connectionString) {
            _connectionString = connectionString;
        }

        public OrdersDbContext CreateDbContext() {
            var optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new OrdersDbContext(optionsBuilder.Options);
        }

        /// <summary>
        /// Создает фабрику по настройкам
        /// </summary>
        /// <param name="configuration">настройки</param>
        /// <param name="connectionStringName">имя пар-ра со строкой подключения</param>
        /// <returns>фабрика</returns>
        public static IRepositoryContextFactory Create(IConfiguration configuration, string connectionStringName = "AppSettings:ConnectionString") {
            var connectionString = configuration[connectionStringName];
            var result = new RepositoryContextFactory(connectionString);
            return result;
        }
    }
}