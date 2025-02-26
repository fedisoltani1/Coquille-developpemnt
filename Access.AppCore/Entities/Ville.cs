namespace Access.AppCore.Entities;

public class Ville : Bases.EntiteBase<int>
{
    public Ville()
    {
        ZoneVilles = new HashSet<ZoneVille>();
        Cites = new HashSet<Cite>();
    }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public int GouvernoratId { get; set; }

    public virtual ICollection<Cite> Cites { get; set; }

    public virtual Gouvernorat Gouvernorat { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
