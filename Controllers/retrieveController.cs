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
        private CategoryContext categoryContext;
        public retrieveController(InventoryContext context,CategoryContext categoryContext)
        {
            this.Context = context;
            this.categoryContext=categoryContext;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Inventory>> all()
        {
            return this.Context.inventory.ToList();
 
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<Inventory>> search(string key){
            List<Inventory> myList=new List<Inventory>();
            Dictionary<int,string> mydict=new Dictionary<int, string>();
            foreach(Category obj in this.categoryContext.category){
                mydict[obj.id]=obj.category_name;
            }
            foreach(Inventory obj in this.Context.inventory){
                string[] str=new string[9];
                str[0]=(obj.id).ToString();
                str[1]=obj.invoice_id.ToString();
                int cat_id=obj.category_id;
                str[2]=mydict[cat_id]; 
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