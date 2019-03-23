using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(4, 5)]
    public class PocetObyvatel : Entity, IExcelEntity
    {
        [Column(0)]
        public string NazevObce { get; set; }
        [Column(1)]
        public int Celkem { get; set; }
        [Column(2)]
        public int Zeny { get; set; }
        [Column(3)]
        public int Muzi { get; set; }


        private Souradnice souradnice;
        public Souradnice Souradnice
        {
            get
            {
                if (souradnice != null)
                    return souradnice;
                else
                    return souradnice = Souradnice.SouradniceZAdresy(NazevObce, "", "");
            }
        }

        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
