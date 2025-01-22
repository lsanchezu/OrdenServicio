using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Minsur.OrdenServicio.Common.Xml
{
    public class HelpXml
    {
        public static XmlDocument ObjectToXml(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
            }
            return xmlDoc;
        }
    }
}
