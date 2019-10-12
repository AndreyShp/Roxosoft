using Roxosoft.Orders.Api.DAL.Context.Contracts;

namespace Roxosoft.Orders.Api.DAL.Repositories {
    /// <summary>
    /// Базовый класс для репозиториев
    /// </summary>
    internal abstract class BaseProvider {
        protected readonly IRepositoryContextFactory RepositoryContextFactory;

        protected BaseProvider(IRepositoryContextFactory repositoryContextFactory) {
            RepositoryContextFactory = repositoryContextFactory;
        }
    }
}