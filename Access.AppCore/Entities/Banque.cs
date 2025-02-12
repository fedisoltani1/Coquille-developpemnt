namespace Access.AppCore.Entities;

public class Banque
{
    public Banque()
    {
        Chequiers = new HashSet<Chequier>();
        Cheques = new HashSet<Cheque>(); // ✅ Initialize collection
    }

    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    // ✅ One-to-Many relationship with Chequiers
    public virtual ICollection<Chequier> Chequiers { get; set; }

    // ✅ One-to-Many relationship with Cheques
    public virtual ICollection<Cheque> Cheques { get; set; }
}
