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
    public class retrieveController : ControllerBase
    {
        private InventoryContext Context;
        public retrieveController(InventoryContext context)
        {
            this.Context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Inventory>> all()
        {
            return this.Context.inventories.ToList();
 
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<Inventory>> search(string key){
            List<Inventory> myList=new List<Inventory>();
            foreach(Inventory obj in this.Context.inventories){
                string[] str=new string[8];
                str[0]=(obj.id).ToString();
                str[1]=obj.invoice_id.ToString();
                str[2]=obj.category_id.ToString();
                str[3]=(string)obj.item_name;
                str[4]=(string)obj.item_model;
                str[5]=obj.quantity.ToString();
                str[6]=obj.price_per_unit.ToString();
                str[7]=(string)obj.date_of_purchase;
                foreach(string st in str){
                    if (st==key){
                        myList.Add(obj);
                        break;
                    }
                }
         
            }
            return myList;
        }

            }
        }