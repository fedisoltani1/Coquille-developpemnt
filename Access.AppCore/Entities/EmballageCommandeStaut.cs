namespace Access.AppCore.Entities;

public class EmballageCommandeStaut : Bases.EntiteBase<int>
{
    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;
}
