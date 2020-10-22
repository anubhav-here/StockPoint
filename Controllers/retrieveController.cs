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
    public class retrieveController : ControllerBase
    {
        private InventoryContext Context;
        private CategoryContext categoryContext;
        public retrieveController(InventoryContext context,CategoryContext categoryContext)
        {
            this.Context = context;
            this.categoryContext=categoryContext;
        }
        public bool compareDates(string start,string end,string cur){
            string[] startDate=start.Split("/");
            string[] endDate=end.Split("/");
            string[] curDate=cur.Split("/");
            //System.Diagnostics.Debug.WriteLine(startDate[2]+" is the start year")
            for(int i=2;i>=0;i--){
                
                if(int.Parse(startDate[i])<=int.Parse(curDate[i]) && int.Parse(endDate[i])>=int.Parse(curDate[i])){
                    continue;
                }
                else{
                    return false;
                }
            }

            return true;
        }
        // [HttpGet("all")]
        // public ActionResult<IEnumerable<Inventory>> all()
        // {
        //     return this.Context.inventory.ToList();
 
        // }
        [HttpGet]
        public ActionResult<IEnumerable<Inventory>> search(string inv_id,string category,string startDate,string endDate){
            List<Inventory> myList=new List<Inventory>();
            Dictionary<int,string> myDict=new Dictionary<int,string>();
            foreach(Category cat in this.categoryContext.category){
                myDict[cat.id]=cat.category_name;
            }
            
            bool[] flag=new bool[4];
            flag[0]=inv_id==null?false:true;
            flag[1]=category==null?false:true;
            flag[2]=startDate==null?false:true;
            flag[3]=endDate==null?false:true;
            if(flag[3]==false){
                endDate=startDate;
            }
            foreach(Inventory ob in this.Context.inventory){
                string cat_name=myDict[ob.category_id];
                
                if(flag[0]==true && ob.invoice_id.ToString()!=inv_id){
                    continue;
                }
                else if(flag[1]==true && cat_name!=category){
                    continue;
                }
                // else if(flag[2]==true && !(startDate.CompareTo(ob.date_of_purchase)<=0) && endDate.CompareTo(ob.date_of_purchase)>=0){
                //     continue;
                // }
                else{
                    if(flag[2]!=false){
                    if(compareDates(startDate,endDate,ob.date_of_purchase)==true){
                    myList.Add(ob);
                    }
                    }
                    else{
                        myList.Add(ob);
                    }
                }
            }
            return myList;
        }

            }
        }