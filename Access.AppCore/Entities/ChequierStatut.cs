namespace Access.AppCore.Entities;

public class ChequierStatut
{
    public ChequierStatut()
    {
        Chequiers = new HashSet<Chequier>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Chequier> Chequiers { get; set; }
}
