using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(12, 5)]
    public class VekoveSlozeni : Entity, IExcelEntity
    {
        [Column(0)]
        public string NazevObce { get; set; }
        [Column(1)]
        public int Celkem { get; set; }
        [Column(2)]
        public int CelkemA { get; set; }
        [Column(3)]
        public int CelkemB { get; set; }
        [Column(4)]
        public int CelkemC { get; set; }
        [Column(5)]
        public int MuziA { get; set; }
        [Column(6)]
        public int MuziB { get; set; }
        [Column(7)]
        public int MuziC { get; set; }
        [Column(8)]
        public int ZenyA { get; set; }
        [Column(9)]
        public int ZenyB { get; set; }
        [Column(10)]
        public int ZenyC { get; set; }
        [Column(11)]
        public int PrumernyVek { get; set; }
        public Souradnice GetSouradnice()
        {
            return null;
        }
    }
}
