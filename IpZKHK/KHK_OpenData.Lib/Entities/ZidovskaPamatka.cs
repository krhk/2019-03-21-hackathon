using KHK_OpenData.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.Entities
{
    public class ZidovskaPamatka : Record, IXMLEntity
    {
        public string Class { get; set; }
        public ZidovskaPamatka() : base()
        {

        }
    }
}
