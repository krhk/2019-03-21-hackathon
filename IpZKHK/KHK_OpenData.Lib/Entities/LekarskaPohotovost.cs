using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(11)]
    public class LekarskaPohotovost : Entity, IExcelEntity
    {
        [Column(0)]
        public string Typ { get; set; }

        [Column(1)]
        public string Urceni { get; set; }

        [Column(2)]
        public string Telefon { get; set; }

        [Column(3)]
        public int KodOkresu { get; set; }

        [Column(4)]
        public string NazevOkresu { get; set; }

        [Column(5)]
        public int KodObce { get; set; }

        [Column(6)]
        public string NazevObce { get; set; }

        [Column(7)]
        public string NazevPoskytovatele { get; set; }

        [Column(8)]
        public string Ulice { get; set; }

        [Column(9)]
        public int PSC { get; set; }

        [Column(10)]
        public string OrdinacniHodiny { get; set; }

        public LekarskaPohotovost()
        {

        }

        private Souradnice souradnice;
        public Souradnice Souradnice
        {
            get
            {
                if (souradnice != null)
                    return souradnice;
                else
                    return souradnice = Souradnice.SouradniceZAdresy(NazevObce, Ulice, "");
            }
        }
        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
