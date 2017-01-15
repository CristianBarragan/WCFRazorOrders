using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWCFServices.Data;

namespace WebApplicationOrders.Models
{
    public class SalesView
    {
        public IEnumerable<SelectListItem> ActionList { get; set; }
        public string ProductId { get; set; }
        public List<GetOrders_Result> Orders { get; set; }
    }
}