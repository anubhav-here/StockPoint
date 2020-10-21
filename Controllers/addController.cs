using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stockpoint.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Stockpoint.Controllers

{
[Route("api/[controller]")]
    [ApiController]
    public class addController : ControllerBase
    {
        private InventoryContext Context;
        public addController(InventoryContext context)
        {
            this.Context = context;
        }

        [HttpPost("add")]
        public ActionResult<Inventory> add([FromBody]Inventory p)
        {
            this.Context.inventories.Add(p);
            return p;
        }
    }
}