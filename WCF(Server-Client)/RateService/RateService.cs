using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RateServiceDummy;

namespace RateServiceDummy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="http://www.example.com/wcf-service-client/")]
    public interface RateService
    {

        [OperationContract]
        ExchangeRatesByRangeDataTable ExchangeRatesByDateRangeByISO(string iso, DateTime from, DateTime to);

        [OperationContract]
        String[] ISOCodes();

        [OperationContract]
        IEnumerator<ExchangeRatesByRangeDataTableRow> getExchangeRatesByRangeDataTableRow(string iso, DateTime from, DateTime to);

  
    }


   
}
