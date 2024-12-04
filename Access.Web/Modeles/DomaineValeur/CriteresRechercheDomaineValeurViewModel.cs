using System.ComponentModel;

namespace Access.Web.Modeles.DomaineValeur
{
    public class CriteresRechercheDomaineValeurViewModel
    {
        [DisplayName("Code")]
        public string Code { get; set; }

        [DisplayName("Description courte")]
        public string DescriptionCourte { get; set; }

        [DisplayName("Date début")]
        public DateTime? DateDebut { get; set; }

        [DisplayName("Date fin")]
        public DateTime? DateFin { get; set; }
    }
}