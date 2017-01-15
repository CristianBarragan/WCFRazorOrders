using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationOrders.Models
{
    public class EmployeeView
    {
        public IEnumerable<SelectListItem> Countries { get; set; }
        public string Country { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public string State { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public string City { get; set; }
    }
}