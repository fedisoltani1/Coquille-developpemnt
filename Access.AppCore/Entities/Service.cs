namespace Access.AppCore.Entities;

public class Service
{
    public Service()
    {
        Clients = new HashSet<Client>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
