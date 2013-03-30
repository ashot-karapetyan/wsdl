using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CBA_Client_ExchangeRatesByDateByISO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

  



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static IEnumerator<CBA.ExchangeRatesDS.ExchangeRatesByRangeRow> getRates(String isoCodec, DateTime from, DateTime to)
        {
            CBA.GateSoapClient client = new CBA.GateSoapClient();
            client.Open();

            
            CBA_Client_ExchangeRatesByDateByISO.CBA.ExchangeRatesDS.ExchangeRatesByRangeDataTable
                ratesTable = client.ExchangeRatesByDateRangeByISO(isoCodec, from, to);
            IEnumerator<CBA.ExchangeRatesDS.ExchangeRatesByRangeRow> enumerator = ratesTable.GetEnumerator();
            return enumerator;
            /*
                        while (enumerator.MoveNext())
                        {
                            CBA.ExchangeRatesDS.ExchangeRatesByRangeRow current = enumerator.Current;
                            int ammount  = current.Amount;
                            String iso = current.ISO;
                            decimal diff = current.Diff;
                            decimal rate = current.Rate;

                        }
             * */
        }


        public static String[] getAvailableCurrencies()
        {
            CBA.GateSoapClient client = new CBA.GateSoapClient();
            client.Open();


            return  client.ISOCodes();
            
        }
    }
}
