namespace Access.AppCore.Entities;

public class ChequeStatut 
{
    public ChequeStatut()
    {
        Cheques = new HashSet<Cheque>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Cheque> Cheques { get; set; }
}
