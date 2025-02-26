namespace Access.AppCore.Entities;

public class ZoneVille : Bases.EntiteBase<int>
{
    public int ZoneId { get; set; }

    public int GouvernoratId { get; set; }

    public int VilleId { get; set; }

    public int CiteId { get; set; }

    public virtual Cite Cite { get; set; } = null!;

    public virtual Gouvernorat Gouvernorat { get; set; } = null!;

    public virtual Ville Ville { get; set; } = null!;

    public virtual Zone Zone { get; set; } = null!;
}
