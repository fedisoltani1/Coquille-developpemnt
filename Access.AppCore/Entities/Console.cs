namespace Access.AppCore.Entities;

public class Console
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateTime CreationLe { get; set; }

    public DateTime? ModificationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public string? ModificationPar { get; set; }

    public int ConsoleStatutId { get; set; }

    public string ConsoleStatutIntitule { get; set; } = null!;

    public int SocieteAgenceSourceId { get; set; }

    public int SocieteAgenceDestinationId { get; set; }

    public string SocieteAgenceSourceIntitule { get; set; } = null!;

    public string SocieteAgenceDestinationIntitule { get; set; } = null!;

    public int? CollaborateurId { get; set; }

    public int? VehiculeId { get; set; }
}
