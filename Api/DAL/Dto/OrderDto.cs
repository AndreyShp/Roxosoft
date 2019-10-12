using System;
using System.Collections.Generic;
using Roxosoft.Orders.Contracts.Enums;

namespace Roxosoft.Orders.Api.DAL.Dto {
    /// <summary>
    /// Описание заказа
    /// </summary>
    public class OrderDto {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime CreationTime { get; set; }
        
        /// <summary>
        /// Статус
        /// </summary>
        public OrderStatus Status { get; set; }
        
        /// <summary>
        /// Продукты заказа
        /// </summary>
        public virtual ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}