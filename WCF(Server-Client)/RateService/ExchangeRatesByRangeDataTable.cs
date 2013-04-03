using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace RateServiceDummy
{
    public class ExchangeRatesByRangeDataTable
    {
        [DataMember]
        public ICollection<ExchangeRatesByRangeDataTableRow> rows{get;set;}
        public ExchangeRatesByRangeDataTable()
        {
            createDummyData();
        }

        private void createDummyData()
        {
            this.rows = new LinkedList<ExchangeRatesByRangeDataTableRow>();
            this.rows.Add(new ExchangeRatesByRangeDataTableRow(1,"USD",0.5m,450m,DateTime.Today));
        }

        
        public IEnumerator<ExchangeRatesByRangeDataTableRow> GetEnumerator()
        {
            return this.rows.GetEnumerator();
        }
    }

}
