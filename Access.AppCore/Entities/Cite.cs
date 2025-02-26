namespace Access.AppCore.Entities;

public class Cite : Bases.EntiteBase<int>
{
    public Cite()
    {
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public int VilleId { get; set; }

    public int GouvernoratId { get; set; }

    public virtual Gouvernorat Gouvernorat { get; set; } = null!;

    public virtual Ville Ville { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
