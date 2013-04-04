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
            this.rows = new LinkedList<ExchangeRatesByRangeDataTableRow>();
        }

        private void createDummyData(String iso, DateTime from, DateTime to)
        {
            ICollection<ExchangeRatesByRangeDataTableRow> draftList = DummyLoader.Deserialize(iso);
            foreach(ExchangeRatesByRangeDataTableRow x in draftList){
                if(x.RateDate<=to && x.RateDate >= from){
                    this.rows.Add(x);
                }
            }
            this.rows.Reverse();
        }

        private void loadFromDb(String iso, DateTime from, DateTime to)
        {
            this.rows = new LinkedList<ExchangeRatesByRangeDataTableRow>(DBHelper.getRatesInInterval(iso, from, to));
           // this.rows.Add(DBHelper.getRatesInInterval(iso, from, to));
        }

        
        public IEnumerator<ExchangeRatesByRangeDataTableRow> GetEnumerator()
        {
            return this.rows.GetEnumerator();
        }

        internal ExchangeRatesByRangeDataTable getData(string iso, DateTime from, DateTime to)
        {
            if (DBHelper.isDBAvailable())
            {
                loadFromDb(iso, from, to);
            }
            else
            {
                createDummyData(iso, from, to);
            }
            
            
            return this;
        }
    }

}
