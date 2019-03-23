using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(7)]
    public class PrispevkovaOrganizace : Entity, IExcelEntity
    {
        [Column(0)]
        public string Nazev { get; set; }

        [Column(1)]
        public string Ulice { get; set; }

        [Column(2)]
        public string CisloPopisne { get; set; }

        [Column(3)]
        public string Mesto { get; set; }

        [Column(4)]
        public int PSC { get; set; }

        [Column(5)]
        public int ICO { get; set; }

        [Column(6)]
        public string Telefon { get; set; }
        public PrispevkovaOrganizace()
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
                    return souradnice = Souradnice.SouradniceZAdresy(Mesto, Ulice, CisloPopisne);
            }
        }

        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
