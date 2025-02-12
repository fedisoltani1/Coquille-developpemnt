namespace Access.AppCore.Entities;

public class ReclamationCommentaire
{
    public int Id { get; set; }

    public int ReclamationId { get; set; }

    public int CollaborateurId { get; set; }

    public string Message { get; set; } = null!;

    public string CreationLe { get; set; } = null!;

    public DateTime CreationPar { get; set; }
}
