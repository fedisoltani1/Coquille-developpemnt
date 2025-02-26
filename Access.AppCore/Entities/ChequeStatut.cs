namespace Access.AppCore.Entities;

public class ChequeStatut : Bases.EntiteBase<int>
{
    public ChequeStatut()
    {
        Cheques = new HashSet<Cheque>();
    }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Cheque> Cheques { get; set; }
}
