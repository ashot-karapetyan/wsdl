using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace RateServiceDummy
{
    public class DBHelper
    {
        private static SqlConnection getConnection()
        {
            return new SqlConnection("user id=idm3;" +
                                      "password=idm3;server=ashot-hp;" +
                                      "Trusted_Connection=yes;" +
                                      "database=RateDB; " +
                                      "connection timeout=30");
        }


        public ICollection<ExchangeRatesByRangeDataTableRow> getRatesInInterval()
        {
             ICollection<ExchangeRatesByRangeDataTableRow> rows  = new LinkedList<ExchangeRatesByRangeDataTableRow>();
            using (SqlConnection innerConnection = getConnection())
            {
                String query = @"select ISO, Diff,Rate,Date from Rate where "
                innerConnection.Open();
                SqlCommand joinCommand = new SqlCommand(query, innerConnection);
                OdbcCommand cmd = innerConnection.CreateCommand();
                using (SqlDataReader resultSet = joinCommand.ExecuteReader())
                {
                    while (resultSet.Read())
                    {
                        new ExchangeRatesByRangeDataTableRow(1, "USD", 0.5m, 450m, DateTime.Today);
                    }
                }
            }


            return rows; 
        }

    }
}