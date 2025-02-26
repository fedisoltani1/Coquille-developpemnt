namespace Access.AppCore.Entities;

public class CommandeStatut : Bases.EntiteBase<int>
{
    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;
}
