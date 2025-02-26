namespace Access.AppCore.Entities;

public class FactureDetail : Bases.EntiteBase<int> 
{
    public int FactureId { get; set; }

    public int CommandeId { get; set; }

    public string CommandeNumero { get; set; } = null!;
}
