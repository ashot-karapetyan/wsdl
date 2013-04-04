using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RateServiceDummy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RateServiceImpl" in code, svc and config file together.
    public class RateServiceImpl : RateService
    {
        public ExchangeRatesByRangeDataTable ExchangeRatesByDateRangeByISO(string iso, DateTime from, DateTime to)
        {
            return new ExchangeRatesByRangeDataTable().getData(iso, from, to);
        }

        public string[] ISOCodes()
        {
            return new String[] { "USD", "EUR", "rubl" };
        }


        public IEnumerator<ExchangeRatesByRangeDataTableRow> getExchangeRatesByRangeDataTableRow(string iso, DateTime from, DateTime to)
        {
            return ExchangeRatesByDateRangeByISO(iso, from, to).GetEnumerator();
        }
    }
}
