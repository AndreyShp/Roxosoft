namespace Roxosoft.Orders.Api.DAL.Dto {
    /// <summary>
    /// Описание продукта в заказе
    /// </summary>
    public class OrderProductDto {
        /// <summary>
        /// Идентификатор продукта в заказе
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public long OrderId { get; set; }
        
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Кол-во
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Заказ
        /// </summary>
        public virtual OrderDto Order { get; set; }
        
        /// <summary>
        /// Продукт
        /// </summary>
        public virtual ProductDto Product { get; set; }
    }
}