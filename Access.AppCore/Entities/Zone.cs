namespace Access.AppCore.Entities;

public class Zone : Bases.EntiteBase<int>
{
    public Zone()
    {
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
