using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.Entities
{
    [Serializable]
    public abstract class Record : Entity, IEntity
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("related")]
        public string Related { get; set; }

        public List<int> RelatedIds
        {
            get
            {
                if (Related != null)
                {
                    List<int> related = new List<int>();
                    foreach (string value in Related.Split(','))
                    {
                        int a;
                        if(int.TryParse(value, out a))
                            related.Add(a);
                    }
                    return related;
                }
                else return null;
            }
        }

        public Souradnice Souradnice => this?.Adresa?.Souradnice;

        [XmlElement(ElementName = "name")]
        public string Jmeno { get; set; }

        [XmlElement(ElementName = "annotation")]
        public string Poznamka { get; set; }


        [XmlElement(ElementName = "region")]
        public string Region { get; set; }


        [XmlElement(ElementName = "phone")]
        public string[] Telefon { get; set; }


        [XmlElement(ElementName = "mobile")]
        public string[] Mobil { get; set; }


        [XmlElement(ElementName = "www")]
        public string[] Web { get; set; }

        [XmlElement(ElementName = "address")]
        public Address Adresa { get; set; }

        [XmlElement(ElementName = "opening_hours")]
        public string OteviraciHodiny { get; set; }

        [XmlElement(ElementName = "admission")]
        public string Vstupne { get; set; }
        public Record()
        {

        }

        public Souradnice GetSouradnice()
        {
            return Souradnice ?? null;
        }
    }
}
