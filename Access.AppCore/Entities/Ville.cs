namespace Access.AppCore.Entities;

public class Ville
{
    public Ville()
    {
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public int GouvernoratId { get; set; }

    public string GouvernoratIntitule { get; set; } = null!;

    public virtual ICollection<Cite> Cites { get; set; } = new List<Cite>();

    public virtual Gouvernorat Gouvernorat { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; } = new List<ZoneVille>();
}
