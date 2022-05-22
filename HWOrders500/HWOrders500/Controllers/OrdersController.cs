using Microsoft.AspNetCore.Mvc;
using HWOrders500.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HWOrders500.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersData>>> GetOrdersData()
        {
            var context = new Models.OrdersDBContext();
            return await context.OrdersTables.Select(t => new OrdersData
            {
                ordersID = t.OrdersId,
                PricePaid = t.PricePaid,
                SalesPersonID = t.SalesPersonId,
                StoreID = t.StoreId,
                CdID = t.CdId,

                date = DateTime.Parse(t.Date)

            }).ToListAsync();
        }

        [HttpPost]
        public void Post([FromBody] newOrder oneOrder)
        {
            var context = new Models.OrdersDBContext();

            var findCd = (from oneCd in context.CdTables
                          where oneCd.CdId == oneOrder.CdID
                          select oneCd).First();


            var findStore = (from oneStore in context.StoreTables
                             where oneStore.StoreId == oneOrder.StoreID
                             select oneStore).First();


            var findSalesPerson = (from onePerson in context.SalesPersonTables
                                   where onePerson.SalesPersonId == oneOrder.SalesPersonID
                                   select onePerson).First();

            OrdersTable newOrders = new OrdersTable();
                newOrders.StoreId = oneOrder.StoreID;
                newOrders.SalesPersonId = oneOrder.SalesPersonID;
                newOrders.CdId = oneOrder.CdID;
                newOrders.PricePaid = oneOrder.PricePaid;
                newOrders.Date = (DateTime.Now).ToString();

                newOrders.Cd = findCd;
                newOrders.SalesPerson = findSalesPerson;
                newOrders.Store = findStore;

            try
            {
                context.OrdersTables.Add(newOrders);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Controller");
            }

        }

    }

    public class OrdersData
    {
        public int ordersID { get; set; }
        public int SalesPersonID { get; set; }
        public int StoreID { get; set; }
        public int CdID { get; set; }
        public int PricePaid { get; set; }
        public DateTime date { get; set; }


    }

    public class newOrder
    {
        public int SalesPersonID { get; set; }
        public int StoreID { get; set; }
        public int CdID { get; set; }
        public int PricePaid { get; set; }
    }
}
