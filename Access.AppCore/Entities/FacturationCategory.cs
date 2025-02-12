namespace Access.AppCore.Entities;

public class FacturationCategory
{
    public FacturationCategory()
    {
        Clients = new HashSet<Client>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
