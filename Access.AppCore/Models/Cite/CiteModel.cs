using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;
using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Models.Ville;

namespace Access.AppCore.Models.Cite
{
    public class CiteModel
    {

        public CiteModel()
        {
            ZoneVilles = new List<ZoneVille>();
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
        public int VilleId { get; set; }

        [Required]
        public int GouvernoratId { get; set; }

        public virtual GouvernoratModel Gouvernorat { get; set; } = null!;

        public virtual VilleModel Ville { get; set; } = null!;

        public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
    }
}
