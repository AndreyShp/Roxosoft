using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roxosoft.Orders.Api.DAL.Context;
using Roxosoft.Orders.Api.DAL.Context.Contracts;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Api.DAL.Repositories.Contracts;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.DAL.Repositories {
    /// <summary>
    /// Репозиторий заказов
    /// </summary>
    internal class OrdersRepository : BaseProvider, IOrdersRepository {
        public OrdersRepository(IRepositoryContextFactory repositoryContextFactory) : base(repositoryContextFactory) { }

        /// <inheritdoc />
        public async Task<ICollection<OrderDto>> GetAsync(Query query,
            Expression<Func<OrderDto, bool>> predicate = null) {
            using (var context = RepositoryContextFactory.CreateDbContext()) {
                var dbQuery = GetQueryableOrders(context, query.NeedProducts);

                if (predicate != null) {
                    dbQuery = dbQuery.Where(predicate);
                }

                var pagination = query?.Pagination ?? new Pagination();
                if (pagination.Offset != null) {
                    dbQuery = dbQuery.Skip(pagination.Offset.Value);
                }

                if (pagination.Count != null) {
                    dbQuery = dbQuery.Take(pagination.Count.Value);
                }

                var result = await dbQuery.ToListAsync();
                return result;
            }
        }

        /// <inheritdoc />
        public async Task<OrderDto> GetAsync(long id) {
            using (var context = RepositoryContextFactory.CreateDbContext()) {
                var result = await GetQueryableOrders(context, true).SingleOrDefaultAsync(e => e.Id == id);
                return result;
            }
        }

        private IQueryable<OrderDto> GetQueryableOrders(OrdersDbContext context, bool needProducts) {
            IQueryable<OrderDto> dbQuery;
            if (needProducts) {
                dbQuery = context.Orders.Include(e => e.OrderProducts).AsQueryable();
            } else {
                dbQuery = context.Orders;
            }

            return dbQuery;
        }
    }
}