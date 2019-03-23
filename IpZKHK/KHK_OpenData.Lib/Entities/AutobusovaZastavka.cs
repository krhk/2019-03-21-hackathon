using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(7)]
    public class AutobusovaZastavka : Entity, IExcelEntity
    {
        [Column(0)]
        public Souradnice Souradnice { get; set; }

        [Column(1)]
        public int Id { get; set; }

        [Column(2)]
        public int CRZ { get; set; }

        [Column(3)]
        public int Oznacnik1 { get; set; }

        [Column(4)]
        public int Oznacnik2 { get; set; }

        public int CRZ_OZNACN
        {
            get
            {
                int result;
                int.TryParse(CRZ.ToString() + Oznacnik2.ToString("00"), out result);
                return result;
            }
        }

        [Column(6)]
        public string Nazev { get; set; }

        public AutobusovaZastavka()
        {
            Souradnice = new Souradnice();
        }

        public Souradnice GetSouradnice()
        {
            return Souradnice ?? null;
        }
    }
}
