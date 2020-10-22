using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stockpoint.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Stockpoint.Controllers

{
[Route("[controller]")]
    [ApiController]
    public class addController : ControllerBase
    {
        private InventoryContext Context;
        public addController(InventoryContext context)
        {
            this.Context = context;
        }

        [HttpPost]
        public ActionResult<Inventory> Post([FromBody]Inventory p)
        {
            this.Context.inventory.Add(p);
            this.Context.SaveChanges();
            return p;
        }
    }
}