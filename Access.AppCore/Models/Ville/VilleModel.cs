using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;
using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Gouvernorat;

namespace Access.AppCore.Models.Ville
{
    public class VilleModel
    {
        public VilleModel()
        {
            ZoneVilles = new List<ZoneVille>();
            Cites = new List<CiteModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Intitule { get; set; } = null!;

        [Required]
        public int GouvernoratId { get; set; }

       

        public List<CiteModel> Cites { get; set; }

        public GouvernoratModel Gouvernorat { get; set; } = null!;

        public List<ZoneVille> ZoneVilles { get; set; }
    }
}