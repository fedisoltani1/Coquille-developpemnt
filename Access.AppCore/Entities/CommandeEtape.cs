namespace Access.AppCore.Entities;

public class CommandeEtape
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public int CommandeStautId { get; set; }

    public string CommandeStautIntitule { get; set; } = null!;

    public bool IsAfficheClient { get; set; }
}
