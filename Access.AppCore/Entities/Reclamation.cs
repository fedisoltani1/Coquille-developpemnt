namespace Access.AppCore.Entities;

public class Reclamation : Bases.EntiteBase<int>
{
    public string? CommandeNumero { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int SocieteDepartementId { get; set; }

    public string SocieteDepartementIntitule { get; set; } = null!;

    public int ReclamationTypeId { get; set; }

    public string ReclamationTypeIntitule { get; set; } = null!;

    public int ReclamationPrioriteId { get; set; }

    public string ReclamationPrioriteIntitule { get; set; } = null!;

    public int ReclamationStatutId { get; set; }

    public string ReclamationStatutIntitule { get; set; } = null!;

    public int? CollaborateurId { get; set; }

    public string Message { get; set; } = null!;

    public int ClientId { get; set; }

    public string ClientIntitule { get; set; } = null!;

    public DateTime CreationLe { get; set; }

    public DateTime? ModificationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public string? ModificationPar { get; set; }

    public bool IsCloture { get; set; }
}
