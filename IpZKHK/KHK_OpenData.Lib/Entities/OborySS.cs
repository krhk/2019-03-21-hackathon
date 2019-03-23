using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(6)]
    public class OborySS : Entity, IExcelEntity
    {
        [Column(0)]
        public int IdResortuSkoly { get; set; }

        [Column(1)]
        public int KodSidla { get; set; }

        [Column(2)]
        public string SidloPO { get; set; }

        [Column(3)]
        public int IdResortuPO { get; set; }

        [Column(4)]
        public string KodOboru { get; set; }

        [Column(5)]
        public string NazevOboru { get; set; }
        public OborySS()
        {
        }


        public Souradnice GetSouradnice()
        {
            return null;
        }
    }
}
