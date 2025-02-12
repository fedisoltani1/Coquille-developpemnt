namespace Access.AppCore.Entities;

public class Cite
{
    public Cite()
    {
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public int VilleId { get; set; }

    public string VilleIntitule { get; set; } = null!;

    public int GouvernoratId { get; set; }

    public string GouvernoratIntitule { get; set; } = null!;

    public virtual Gouvernorat Gouvernorat { get; set; } = null!;

    public virtual Ville Ville { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
