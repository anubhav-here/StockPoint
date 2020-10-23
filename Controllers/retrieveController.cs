using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stockpoint.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Stockpoint.Controllers
{
public class result{
            public int id { get; set; }
            public int invoice_id {get;set;}
            public string category_name { get; set; }
            public string item_name { get; set; }
            public string item_model { get; set; }
            public int quantity { get; set; }
            public int price_per_unit { get; set; }
            public string date_of_purchase { get; set; }


            public result(Inventory ob,string cat){
                this.id=ob.id;
                this.invoice_id = ob.invoice_id;
                //this.category_id = category_id;
                this.category_name=cat;
                this.item_name = ob.item_name;
                this.item_model = ob.item_model;
                this.quantity = ob.quantity;
                this.price_per_unit = ob.price_per_unit;
                this.date_of_purchase = ob.date_of_purchase;   
            }

}
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
      //  [EnableCors("AnotherPolicy")]
        [HttpGet]
        public ActionResult<IEnumerable<result>> search(string inv_id,string category,string startDate,string endDate){
            List<result> myList=new List<result>();
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
                else{
                    if(flag[2]!=false){
                    if(compareDates(startDate,endDate,ob.date_of_purchase)==true){
                        result ob2=new result(ob,cat_name);
                        myList.Add(ob2);
                    }
                    }
                    else{
                        result ob2=new result(ob,cat_name);
                        myList.Add(ob2);
                    }
                }
            }
            return myList;
        }

            }
        }
