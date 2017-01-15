 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationOrders.Business;
using WebApplicationOrders.Models;

namespace WebApplicationOrders.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        SalesBU salesBu = new SalesBU();

        public ActionResult Index()
        {
            EmployeeView employeeView = new EmployeeView()
            {
                Countries = salesBu.getCountry(),
                States = salesBu.emptyList(),
                Cities = salesBu.emptyList(),
            };
            return View(employeeView);
        }

        public JsonResult GetState(string id)
        {
            return Json(salesBu.getState(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCity(string id)
        {
            return Json(salesBu.getCity(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        //public void Insert(EmployeeData da)
        //{
        //    salesBu.insertEmployeeData(da);
        //}

        [HttpPost]
        public void Insert(EmployeeView ev)
        {
            salesBu.insertEmployee(ev);
        }
    }
}
