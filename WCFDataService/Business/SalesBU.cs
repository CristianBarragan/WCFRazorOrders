using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationOrders.Models;
using MyWCFServices.Data;

namespace MyWCFServices.Business
{
    public class SalesBU
    {
        private OrdersEntities model;

        public List<GetOrders_Result> getCustomerOrders(int id)
        {
            using (model = new OrdersEntities())
            {
                return model.GetOrders(id, null, null).ToList();
            }
        }

        public List<Customer> getCustomers()
        {
            using (model = new OrdersEntities())
            {
                return model.Customer.ToList();
            }
        }

        public List<Product> getProducts()
        {
            using (model = new OrdersEntities())
            {
                return model.Product.ToList();
            }
        }

        public IEnumerable<SelectListItem> getSales()
        {
            SalesView sales = new SalesView();
            var customers = getCustomers();
            sales.ActionList = from customer in customers
                               select new SelectListItem
                               {
                                   Text = customer.Name,
                                   Value = customer.Id.ToString()
                               };
            return sales.ActionList;            
        }

        public IEnumerable<SelectListItem> getCountry()
        {
            using (model = new OrdersEntities())
            {
                var country =  model.Country.ToList();
                var countryList = country.Select(c => new SelectListItem()
                    {
                        Text = c.CountryName,
                        Value = c.CountryID.ToString(),
                    }).ToList();
                countryList.Insert(0, empty());
                return countryList;
            }
        }

        public IEnumerable<SelectListItem> emptyList()
        {
            List<SelectListItem> list = new List<WebApplicationOrders.Models.SelectListItem>();
            list.Add(empty());
            return list;
        }

        private SelectListItem empty()
        {
            SelectListItem emptyItem = new SelectListItem()
            {
                Text = "Select",
                Value = "0",
            };
            return emptyItem;
        }

        public IEnumerable<SelectListItem> getState(int id)
        {
            using (model = new OrdersEntities())
            {
                var states = model.State.Where(s => s.CountryID == id).ToList();
                var stateList = states.Select(s => new SelectListItem()
                    {
                        Text = s.StateName,
                        Value = s.StateID.ToString(),
                    }).ToList();
                stateList.Insert(0, empty());
                return stateList;
            }
        }

        public IEnumerable<SelectListItem> getCity(int p)
        {
            using (model = new OrdersEntities())
            {
                var cities = model.City.Where(c => c.StateID == p).ToList();
                var cityList = cities.Select(c => new SelectListItem()
                    {
                        Text = c.CityName,
                        Value = c.CityID.ToString(),
                    }).ToList();
                cityList.Insert(0, empty());
                return cityList;
            }
        }

        public void insertEmployeeData(EmployeeData da)
        {
            tbl_reg reg = new tbl_reg();
            reg.City = da.City;
            reg.state = da.State;
            reg.Country = da.Country;
            using (model = new OrdersEntities())
            {
                model.AddTotbl_reg(reg);
                model.SaveChanges();
            }
        }

        public void insertEmployee(EmployeeView ev)
        {
            tbl_reg reg = new tbl_reg();
            reg.City = ev.City;
            reg.state = ev.State;
            reg.Country = ev.Country;
            using (model = new OrdersEntities())
            {
                model.AddTotbl_reg(reg);
                model.SaveChanges();
            }
        }
    }

}