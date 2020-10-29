using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;


namespace WPF_1
{
    public class Repository
    {
        internal static bool ReadFile(string fileName, out ObservableCollection<Depter> depter)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Depter>));

            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            depter = (ObservableCollection<Depter>)serializer.Deserialize(reader);
            reader.Close();

            return true;
        }

        internal static void SaveFile(string fileName, ObservableCollection<Depter> depter)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Depter>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, depter);
            writer.Close();
        }
    }
}
