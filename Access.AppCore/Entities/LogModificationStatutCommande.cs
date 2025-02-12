namespace Access.AppCore.Entities;

public class LogModificationStatutCommande
{
    public int Id { get; set; }

    public int CommandeId { get; set; }

    public string CommandeNumero { get; set; } = null!;

    public int CommandeStatutActuelId { get; set; }

    public string CommandeStatutActuelIntitule { get; set; } = null!;

    public int CommandeStatutModifierId { get; set; }

    public string CommandeStatutModifierIntitule { get; set; } = null!;

    public DateTime ModificationLe { get; set; }

    public string ModificationPar { get; set; } = null!;
}
