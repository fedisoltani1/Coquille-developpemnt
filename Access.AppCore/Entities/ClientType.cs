namespace Access.AppCore.Entities;

public class ClientType : Bases.EntiteBase<int>
{
    public ClientType()
    {
        Clients = new HashSet<Client>();
    }

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
