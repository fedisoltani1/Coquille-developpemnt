using System.ComponentModel.DataAnnotations;
using Access.Web.Modeles.Cite;
using Access.Web.Modeles.Gouvernorat;

namespace Access.Web.Modeles.Ville
{
    public class VilleViewModel
    {
        public VilleViewModel()
        {
            Cites = new List<CiteViewModel>();
        }

        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le code ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Code")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "L’intitulé est obligatoire.")]
        [StringLength(100, ErrorMessage = "L’intitulé ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; } = null!;

        [Required]
        [Display(Name = "GouvernoratId")]
        public int GouvernoratId { get; set; }

        [Display(Name = "Gouvernorat")]
        public GouvernoratViewModel Gouvernorat { get; set; } = null!;

        [Display(Name = "Cités")]
        public List<CiteViewModel> Cites { get; set; }
    }
}
