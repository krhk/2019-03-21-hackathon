using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.Models
{
    
    public class Address
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("subreg")]
        public string Subreg { get; set; }

        [XmlElement(ElementName = "gps")]
        public double[] GPS { get; set; }

        private Souradnice souradnice;
        public Souradnice Souradnice {
            get
            {
                if (souradnice != null)
                    return souradnice;
                if (GPS != null && GPS.Length == 2)
                    return souradnice = new Souradnice(GPS[0], GPS[1]);
                else return souradnice = null;
            }
        }

        [XmlElement(ElementName = "locality")]
        public string Lokalita { get; set; }

        [XmlElement(ElementName = "region")]
        public string Region { get; set; }

        [XmlElement(ElementName = "street")]
        public string Ulice { get; set; }

        [XmlElement(ElementName = "cp")]
        public string CisloPopisne { get; set; }

        [XmlElement(ElementName = "municipality")]
        public string Obec { get; set; }

        [XmlElement(ElementName = "zip")]
        public string PSC { get; set; }

        public Address()
        {

        }
    }
}
