namespace Access.AppCore.Models.DomaineValeur
{
    public class DomaineValeurElementModel
    {
        public int Id { get; set; }

        public string CodeDomaineValeur { get; set; }

        public string Code { get; set; }

        public string DescriptionCourte { get; set; }

        public string DescriptionComplete { get; set; }

        public int SequenceAffichage { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public DomaineValeurModel DomaineValeur { get; set; }
    }
}
