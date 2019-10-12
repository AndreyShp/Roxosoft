using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Api.DAL.Repositories.Contracts;
using Roxosoft.Orders.Api.Managers.Contracts;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.Managers {
    /// <summary>
    /// Менеджер для работы с заказами
    /// </summary>
    public class OrdersManager : IOrdersManager {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersManager(IOrdersRepository ordersRepository, IMapper mapper) {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ICollection<Order>> GetAsync(Query query, Expression<Func<OrderDto, bool>> predicate = null) {
            var orders = await _ordersRepository.GetAsync(query, predicate);
            var result = _mapper.Map<ICollection<Order>>(orders);
            return result;
        }

        /// <inheritdoc />
        public async Task<Order> GetAsync(long id) {
            var order = await _ordersRepository.GetAsync(id);
            var result = _mapper.Map<Order>(order);
            return result;
        }
    }
}