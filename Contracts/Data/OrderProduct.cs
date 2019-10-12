namespace Roxosoft.Orders.Contracts.Data {
    /// <summary>
    /// Описание продукта в заказе
    /// </summary>
    public class OrderProduct {
        /// <summary>
        /// Идентификатор продукта в заказе
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Кол-во
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}