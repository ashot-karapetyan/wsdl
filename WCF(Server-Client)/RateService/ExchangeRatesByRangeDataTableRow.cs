using System;
using System.Runtime.Serialization;
namespace RateServiceDummy
{

    [DataContract]
    public class ExchangeRatesByRangeDataTableRow
    {
        [DataMember]
        public int Ammount;
        [DataMember]
        public String ISO;
        [DataMember]
        public decimal Diff;
        [DataMember]
        public decimal Rate;

        [DataMember]
        public DateTime RateDate;

        public ExchangeRatesByRangeDataTableRow()
        {

        }

        public ExchangeRatesByRangeDataTableRow(int Ammount, String ISO, decimal Diff, decimal Rate, DateTime RateDate)
        {
            this.Ammount = Ammount;
            this.ISO = ISO;
            this.Diff = Diff;
            this.Rate = Rate;
            this.RateDate = RateDate;
        }

    }
}