using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(15)]
    public class SocialniZarizeni : Entity, IExcelEntity
    {
        [Column(0)]
        public int Id { get; set; }
        [Column(1)]
        public string NazevPoskytovatele { get; set; }
        [Column(2)]
        public string Ulice { get; set; }
        [Column(3)]
        public string CisloPopisne { get; set; }
        [Column(4)]
        public string Mesto { get; set; }
        [Column(5)]
        public int PSC { get; set; }
        [Column(9)]
        public string Telefon { get; set; }
        [Column(12)]
        public string NazevSluzby { get; set; }
        [Column(13)]
        public string DruhSluzby { get; set; }

        private Souradnice souradnice;
        public Souradnice Souradnice
        {
            get
            {
                if (souradnice != null)
                    return souradnice;
                else
                    return souradnice = Souradnice.SouradniceZAdresy(Mesto, Ulice, CisloPopisne);
            }
        }
        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
