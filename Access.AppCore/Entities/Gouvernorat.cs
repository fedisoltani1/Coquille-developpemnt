namespace Access.AppCore.Entities;

public class Gouvernorat
{
    public Gouvernorat()
    {
        Cites = new HashSet<Cite>();
        Villes = new HashSet<Ville>();
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Cite> Cites { get; set; }

    public virtual ICollection<Ville> Villes { get; set; }

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
