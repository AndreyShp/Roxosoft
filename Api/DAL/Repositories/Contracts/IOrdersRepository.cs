using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.DAL.Repositories.Contracts {
    /// <summary>
    /// Интерфейс репозитория заказов
    /// </summary>
    public interface IOrdersRepository {
        /// <summary>
        /// Получает заказы
        /// </summary>
        /// <param name="query">запрос для выборки</param>
        /// <param name="predicate">фильтр (необязателен). Если не указать - вернем все данные</param>
        /// <returns>заказы попавшие под фильтр</returns>
        Task<ICollection<OrderDto>> GetAsync(Query query, Expression<Func<OrderDto, bool>> predicate = null);

        /// <summary>
        /// Получает заказ вместе с продуктами
        /// </summary>
        /// <param name="id">идентификатор заказа который нужно вернуть</param>
        /// <returns>заказ</returns>
        Task<OrderDto> GetAsync(long id);
    }
}