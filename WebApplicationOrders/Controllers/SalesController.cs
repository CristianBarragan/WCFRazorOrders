using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationOrders.Business;
using WebApplicationOrders.Models;

namespace WebApplicationOrders.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/

        SalesBU salesBu = new SalesBU();
        //Service.

        [HttpGet]
        public ActionResult Index()
        {
            SalesView salesView = new SalesView();
            salesView.ActionList = salesBu.getSales();
            return View(salesView);
        }

        [HttpPost]
        public ActionResult Index(SalesView salesView)
        {
            salesView.ActionList = salesBu.getSales();
            salesView.Orders = salesBu.getCustomerOrders(Int32.Parse(salesView.ProductId));
            return View(salesView);
        }

    }
}
