namespace Roxosoft.Orders.Contracts.Data {
    /// <summary>
    /// Запрос на получение заказов
    /// </summary>
    public class Query {
        /// <summary>
        /// Нужно ли получать продукты
        /// </summary>
        public bool NeedProducts { get; set; }
        
        /// <summary>
        /// Пагинация
        /// </summary>
        public Pagination Pagination { get; set; }
    }
}