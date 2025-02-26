using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;
using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Ville;

namespace Access.AppCore.Models.Gouvernorat
{
    public class GouvernoratModel
    {
        public GouvernoratModel()
        {
            Cites = new List<CiteModel>();
            ZoneVilles = new List<ZoneVille>();
            Villes= new List<VilleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Intitule { get; set; } = null!;

        public List<CiteModel> Cites { get; set; }

        public List<VilleModel> Villes { get; set; }

        public List<ZoneVille> ZoneVilles { get; set; }
    }
}
