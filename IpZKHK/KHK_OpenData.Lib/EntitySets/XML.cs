using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.EntitySets
{
    [XmlRoot(ElementName = "dsti_data")]
    public sealed class XML<T> : EntitySet<T>, IEntitySet<T> where T : IXMLEntity, new()
    {
        public XML() : base()
        {
            Entities = new List<T>();
        }
        public XML(IDataProvider dataProvider) : base(dataProvider)
        {
            this.Entities = ToList();
        }

        public override List<T> ToList()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XML<T>));
            Stream stream = DataProvider.GetStream().Result;
            StreamReader reader = new StreamReader(stream);
            XML<T> xml = (XML<T>)serializer.Deserialize(reader);
            reader.Dispose();
            stream.Dispose();
            return xml.Entities;
        }

    }
}
