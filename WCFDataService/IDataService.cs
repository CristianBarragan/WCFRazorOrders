using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace MyWCFServices
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        List<GetOrdersDTO> getCustomerOrders(int id);
    }

    [DataContract]
    public class GetOrdersDTO
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public int? TotalUnits { get; set; }
        [DataMember]
        public decimal? Total { get; set; }
    }
}
