using Access.AppCore.Entities.Bases;

namespace Access.AppCore.Entities
{
    public class DomaineValeurElement : EntiteBase<int>
    {
        public string CodeDomaineValeur { get; set; }

        public string Code { get; set; }

        public string DescriptionCourte { get; set; }

        public string DescriptionComplete { get; set; }

        public int SequenceAffichage { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public virtual DomaineValeur DomaineValeur { get; set; }
    }
}