using KHK_OpenData.Lib.Interfaces;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.Models
{
    public abstract class EntitySet<T> : IEntitySet<T> where T : IEntity
    {

        [XmlElement(ElementName = "record")]
        public List<T> Entities { get; set; }
        protected virtual IDataProvider DataProvider {get; set;}

        protected EntitySet()
        {
        }

        protected EntitySet(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public List<T> GetList()
        {
            return Entities;
        }

        public virtual List<T> ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}
