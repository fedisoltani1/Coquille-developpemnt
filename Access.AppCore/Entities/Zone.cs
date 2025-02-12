namespace Access.AppCore.Entities;

public class Zone
{
    public Zone()
    {
        ZoneVilles = new HashSet<ZoneVille>();
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public virtual ICollection<ZoneVille> ZoneVilles { get; set; }
}
