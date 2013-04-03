using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsClient.RateGate;
using System.Collections;
namespace WindowsFormsClient
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




        public static IEnumerator getRates(String isoCodec, DateTime from, DateTime to)
        {
            
            RateServiceClient client = new RateServiceClient();
            client.Open();
             
            return client.ExchangeRatesByDateRangeByISO(isoCodec, from, to).rows.GetEnumerator();
           
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
            RateServiceClient client = new RateServiceClient();
            client.Open();


            return client.ISOCodes();

        }
    }
}
