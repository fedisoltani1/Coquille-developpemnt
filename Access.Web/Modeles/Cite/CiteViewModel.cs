using System.ComponentModel.DataAnnotations;
using Access.Web.Modeles.Gouvernorat;
using Access.Web.Modeles.Ville;

namespace Access.Web.Modeles.Cite
{
    public class CiteViewModel
    {
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
        [Display(Name = "VilleId")]
        public int VilleId { get; set; }

        [Required]
        [Display(Name = "GouvernoratId")]
        public int GouvernoratId { get; set; }

        public GouvernoratViewModel Gouvernorat { get; set; }

        public VilleViewModel Ville { get; set; }

    }
}
