namespace Access.AppCore.Entities;

public class FormulaireSatisfaction
{

    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int NombreParticipants { get; set; }

    public string Intitule { get; set; } = null!;

    public DateTime CreationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public bool IsActif { get; set; }
}
