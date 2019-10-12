using System.Collections.Generic;
using System.Threading.Tasks;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Contracts {
    /// <summary>
    /// Интерфейс сервиса
    /// </summary>
    public interface IOrdersApi {
        /// <summary>
        /// Получает заказы
        /// </summary>
        /// <param name="query">запрос на выборку данных</param>
        /// <returns>заказы</returns>
        Task<ICollection<Order>> Get(Query query = null);

        /// <summary>
        /// Получает заказ с продуктами
        /// </summary>
        /// <param name="id">идентификатор заказа</param>
        /// <returns>заказ</returns>
        Task<Order> Get(long id);
    }
}