using Access.Web.Modeles.Cite;
using Access.Web.Modeles.Gouvernorat;
using Access.Web.Modeles.Ville;

namespace Access.Web.Modeles.Localisation
{
    public class LocalisationViewModel
    {
        public LocalisationViewModel()
        {
            Gouvernorats = new List<GouvernoratViewModel>();
            Villes = new List<VilleViewModel>();
            Cites = new List<CiteViewModel>();
        }

        public List<GouvernoratViewModel> Gouvernorats { get; set; }

        public List<VilleViewModel> Villes { get; set; }

        public List<CiteViewModel> Cites { get; set; }
    }
}
