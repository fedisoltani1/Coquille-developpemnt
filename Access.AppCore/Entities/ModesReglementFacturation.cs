namespace Access.AppCore.Entities;

public class ModesReglementFacturation
{
    public ModesReglementFacturation()
    {
        Clients = new HashSet<Client>();
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
