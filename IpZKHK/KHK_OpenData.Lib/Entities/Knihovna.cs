using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(9)]
    public class Knihovna : Entity, IExcelEntity
    {
        [Column(0)]
        public string Okres { get; set; }

        [Column(1)]
        public string Typ { get; set; }

        [Column(2)]
        public string Nazev { get; set; }

        [Column(3)]
        public string Adresa { get; set; }

        [Column(4)]
        public string Telefon { get; set; }

        [Column(5)]
        public string Email { get; set; }

        [Column(6)]
        public string Popis { get; set; }

        [Column(7)]
        public string ProvozniDobaProDospele { get; set; }

        [Column(8)]
        public string ProvozniDobaProDeti { get; set; }


        public Knihovna()
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
                    return souradnice = Souradnice.SouradniceZAdresy(Okres, "", "");
            }
        }

        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
