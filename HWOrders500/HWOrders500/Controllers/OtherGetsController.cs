using Microsoft.AspNetCore.Mvc;
using HWOrders500.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HWOrders500.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class otherGetsController : ControllerBase
    {
        // GET: api/<otherGetsController>
        [HttpGet]
        [ActionName("GetsalesPerson")]
        public IEnumerable<SalesPersonTable> GetSalesPerson()
        {
            var context = new Models.OrdersDBContext();
            return context.SalesPersonTables.ToList();
        }

        [HttpGet]
        [ActionName("GetStore")]
        public IEnumerable<StoreTable> GetStoreTable()
        {
            var context = new Models.OrdersDBContext();
            return context.StoreTables.ToList();
        }

        [HttpGet]
        [ActionName("GetCd")]
        public IEnumerable<CdTable> Get()
        {
            var context = new Models.OrdersDBContext();
            return context.CdTables.ToList();
        }


    }
}
