using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Resources;
using System.Configuration;


namespace RateServiceDummy
{
    public class DBHelper
    {
        private static SqlConnection getConnection()
        {
            var connectionURL  = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
            return new SqlConnection(connectionURL);
        }


        public static ICollection<ExchangeRatesByRangeDataTableRow> getRatesInInterval(String iso, DateTime from, DateTime to)
        {
            LinkedList<ExchangeRatesByRangeDataTableRow> rows = new LinkedList<ExchangeRatesByRangeDataTableRow>();
            using (SqlConnection innerConnection = getConnection())
            {
                innerConnection.Open();
                SqlCommand selectCommand = innerConnection.CreateCommand();
                selectCommand.CommandText = @"select Ammount, D.Date
                                                from dbo.Rate R join
					                                                (
					                                                select CurrencyId,CurrencyName
					                                                from Currency
					                                                where CurrencyName = '"+iso+@"') C  on R.CurrencyId = C.CurrencyId join 
                                                (
	                                                select [Date],[DateId]
	                                                from [Date]
	                                                where Date.Date   BETWEEN '" + from.ToString("yyyy-MM-dd") + @"' AND '" + to.ToString("yyyy-MM-dd") + @"' ) D on R.DateId = D.DateId ";
           
                using (SqlDataReader resultSet = selectCommand.ExecuteReader())
                {

                    if (resultSet.Read())
                    {
                        decimal prevAmount = (decimal)resultSet["Ammount"];
                        decimal currentAmmount = (decimal)resultSet["Ammount"];
                        rows.AddFirst(new ExchangeRatesByRangeDataTableRow(1, iso, 0, currentAmmount, (DateTime)resultSet["Date"]));
                        while (resultSet.Read())
                        {
                            currentAmmount = (decimal)resultSet["Ammount"];
                            rows.AddFirst(new ExchangeRatesByRangeDataTableRow(1, iso, currentAmmount - prevAmount, currentAmmount, (DateTime)resultSet["Date"]));
                            prevAmount = currentAmmount;

                        }
                    }
                }
            }
          //  DummyLoader.Serialize(iso,rows); 
            return rows; 
        }


        public static bool isDBAvailable()
        {
            try
            {
               SqlConnection conn =  getConnection();
               conn.Open();
               return true;
            }catch(Exception e){
                return false;
            }

        }

    }
}