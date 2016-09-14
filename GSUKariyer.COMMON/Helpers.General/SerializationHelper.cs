using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace GSUKariyer.COMMON
{
    public class SerializationHelper<T>
    {
        public static T DeserializeDocument(XmlDocument document)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlNodeReader reader = new XmlNodeReader(document);
            T formObj = (T)serializer.Deserialize(reader);

            return formObj;
        }


        public static T Deserialize(string serializedValue)
        {
            using (StringReader stringReader = new StringReader(serializedValue))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(stringReader);
            }
        }


        public static string SerializeToString(T value)
        {
            using (StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringWriter, value);
                return stringWriter.ToString();
            }
        }

        public static string SerializeToString(T value, XmlSerializerNamespaces ns)
        {
            using (StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringWriter, value, ns);
                return stringWriter.ToString();
            }
        }


        public static XmlDocument SerializeToXml(T value)
        {
            XmlDocument document = new XmlDocument();
            document.PreserveWhitespace = true;
            document.LoadXml(SerializationHelper<T>.SerializeToString(value));
            return document;
        }
    }
}
