namespace Roxosoft.Orders.Api.DAL.Context.Contracts {
    /// <summary>
    /// Интерфейс фабрики создания контекта для работы с базой
    /// </summary>
    public interface IRepositoryContextFactory {
        /// <summary>
        /// Создает контекст для работы с базой
        /// </summary>
        /// <returns>контекст для работы с базой</returns>
        OrdersDbContext CreateDbContext();
    }
}