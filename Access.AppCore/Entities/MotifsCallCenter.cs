namespace Access.AppCore.Entities;

public class MotifsCallCenter
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }
}
