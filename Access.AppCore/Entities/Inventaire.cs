namespace Access.AppCore.Entities;

public class Inventaire : Bases.EntiteBase<int>
{
    public string Numero { get; set; } = null!;

    public int SocieteAgenceId { get; set; }

    public DateTime Date { get; set; }

    public string CreationLe { get; set; } = null!;

    public string CreationPar { get; set; } = null!;

    public int InventaireStatutId { get; set; }
}
