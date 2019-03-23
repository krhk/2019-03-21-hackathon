using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;

namespace KHK_OpenData.Lib.Entities
{
    [ColumnCount(8)]
    public class NaslednaPece : Entity, IExcelEntity
    {
        [Column(0)]
        public string Poskytovatel { get; set; }

        [Column(1)]
        public string PravniForma { get; set; }

        [Column(2)]
        public int KodObce { get; set; }

        [Column(3)]
        public string NazevObce { get; set; }

        [Column(4)]
        public string Ulice { get; set; }

        [Column(5)]
        public string CisloPopisne { get; set; }

        [Column(6)]
        public int PSC { get; set; }

        [Column(7)]
        public string Telefon { get; set; }


        public NaslednaPece()
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
                    return souradnice = Souradnice.SouradniceZAdresy(NazevObce, Ulice, CisloPopisne);
            }
        }
        public Souradnice GetSouradnice()
        {
            return Souradnice;
        }
    }
}
