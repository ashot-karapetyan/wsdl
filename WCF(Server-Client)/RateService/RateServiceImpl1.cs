using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateService
{
    public class RateServiceImpl1 : WCF.RateService
    {

        public ExchangeRatesByRangeDataTable ExchangeRatesByDateRangeByISO(string iso, DateTime from, DateTime to)
        {
            return new ExchangeRatesByRangeDataTable();
        }

        public string[] ISOCodes()
        {
            return new String[] {"USD","EUR","ruble"};
        }

        
    }
}