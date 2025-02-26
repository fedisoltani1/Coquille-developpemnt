using System.ComponentModel.DataAnnotations;
using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Ville;

namespace Access.Web.Modeles.Gouvernorat
{
    public class GouvernoratViewModel
    {
        public GouvernoratViewModel() 
        {
        }

        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'intitulé est obligatoire.")]
        [StringLength(200, ErrorMessage = "L'intitulé ne doit pas dépasser 200 caractères.")]
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; } = null!;

        [Required(ErrorMessage = "Le code est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le code ne doit pas dépasser 50 caractères.")]
        [Display(Name = "Code")]
        public string Code { get; set; } = null!;

        public List<CiteModel> Cites { get; set; }

        public List<VilleModel> Villes { get; set; }

        //public List<ZoneVille> ZoneVilles { get; set; }
    }
}
