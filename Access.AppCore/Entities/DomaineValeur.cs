using Access.AppCore.Entities.Bases;

namespace Access.AppCore.Entities
{
    public class DomaineValeur : EntiteBase<int>
    {
        public DomaineValeur()
        {
            Elements = new HashSet<DomaineValeurElement>();
        }

        public string Code { get; set; }

        public string DescriptionCourte { get; set; }

        public string DescriptionComplete { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public virtual ICollection<DomaineValeurElement> Elements { get; set; }
    }
}
