using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace StrarterProject
{
    class DbHelper
    {

        private static SqlConnection getConnection()
        {
            return new SqlConnection("user id=idm3;" +
                                      "password=idm3;server=ashot-hp;" +
                                      "Trusted_Connection=yes;" +
                                      "database=RateDB; " +
                                      "connection timeout=30");
        }

        public static void insertDummyData()
        {
            SqlConnection connection = getConnection();
            int[] rates = new int[] { 400, 500, 500, 600, 10, 15 };
            try
            {
                connection.Open();
                Random random = new Random();
                for (int currencyId = 1; currencyId <= 3; currencyId++)
                {
                    String query = @"select *
                                    from [Currency] , [Date]
                                    where CurrencyId = " + currencyId;


                    using (SqlConnection innerConnection = getConnection())
                    {
                        innerConnection.Open();
                        SqlCommand joinCommand = new SqlCommand(query, innerConnection);
                        using (SqlDataReader resultSet = joinCommand.ExecuteReader())
                        {
                            while (resultSet.Read())
                            {
                                String insertQuery = @"insert into Rate 
                                              values(" +
                                                      resultSet["DateId"] + "," +
                                                      resultSet["CurrencyId"] + "," +
                                                      random.Next(rates[2 * (currencyId - 1)], rates[2 * (currencyId - 1) + 1]) + ")";

                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }




                }


            }
            finally
            {
                Console.ReadKey();
                connection.Close();
            }
        }




    }
}
