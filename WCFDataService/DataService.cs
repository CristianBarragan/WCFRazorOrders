using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MyWCFServices.Business;
using MyWCFServices.Data;

namespace MyWCFServices
{
    public class DataService : IDataService
    {
        private SalesBU salesBu;

        public DataService()
        {
            salesBu = new SalesBU();
        }

        public List<GetOrdersDTO> getCustomerOrders(int id)
        {

            List<GetOrdersDTO> dto = new List<GetOrdersDTO>();
            List<GetOrders_Result> result = salesBu.getCustomerOrders(id);
            dto = result.Select(r => new GetOrdersDTO()
            {
                CustomerName = r.CustomerName,
                ProductName = r.ProductName,
                Date = r.Date,
                TotalUnits = r.TotalUnits,
                Total = r.Total,
            }).ToList();
            return dto;
        }
    }
}
