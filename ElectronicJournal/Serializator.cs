using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public class Serializator
    {
        public void SerializeStorage(DataStorage storage)
        {
            //Create a stream to serialize the object to.  
            MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataStorage));
            ser.WriteObject(ms, storage);
            byte[] json = ms.ToArray();
            ms.Close();
            Console.WriteLine(Encoding.UTF8.GetString(json, 0, json.Length));
        }
    }
}
