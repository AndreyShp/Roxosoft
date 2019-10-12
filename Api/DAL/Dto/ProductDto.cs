using System.Collections.Generic;

namespace Roxosoft.Orders.Api.DAL.Dto {
    /// <summary>
    /// Продукт
    /// </summary>
    public class ProductDto {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Заказы этого продукта
        /// </summary>
        public virtual ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}