using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roxosoft.Orders.Api.Managers.Contracts;
using Roxosoft.Orders.Contracts;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase, IOrdersApi {
        private readonly IOrdersManager _ordersManager;

        public OrdersController(IOrdersManager ordersManager) {
            _ordersManager = ordersManager;
        }

        /// <inheritdoc />
        // GET api/orders
        [HttpGet]
        public async Task<ICollection<Order>> Get([FromQuery]Query query = null) {
            var result = await _ordersManager.GetAsync(query);
            return result;
        }

        /// <inheritdoc />
        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<Order> Get(long id) {
            var result = await _ordersManager.GetAsync(id);
            return result;
        }

        // POST api/orders
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}