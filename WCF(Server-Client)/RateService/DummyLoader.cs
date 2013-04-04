using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RateServiceDummy
{
    public class DummyLoader
    {




        public static void Serialize(String iso, LinkedList<ExchangeRatesByRangeDataTableRow> dt)
        {
            try
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, dt);
                using (FileStream f = new FileStream("c:/test/" + iso + ".bin", FileMode.Create | FileMode.Open))
                {
                    byte[] bytes = stream.GetBuffer();
                    f.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

        }


        public static LinkedList<ExchangeRatesByRangeDataTableRow> Deserialize(String iso)
        {
            try
            {
                byte[] bytes = new byte[1024 * 1024 * 20];
                using (FileStream f = new FileStream("c:/test/" + iso + ".bin", FileMode.Create | FileMode.Open))
                {

                    f.Read(bytes, 0, bytes.Length);
                }
                System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
                System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as LinkedList<ExchangeRatesByRangeDataTableRow>;
            }
            catch (Exception e)
            {

                Console.Write(e.StackTrace);
                return null;
            }

        }
    }
}