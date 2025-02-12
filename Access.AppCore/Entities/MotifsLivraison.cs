namespace Access.AppCore.Entities;

public class MotifsLivraison
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsRetry { get; set; }

    public bool IsActif { get; set; }
}
