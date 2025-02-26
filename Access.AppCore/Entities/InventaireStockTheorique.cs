namespace Access.AppCore.Entities;

public class InventaireStockTheorique : Bases.EntiteBase<int>
{
    public int InventaireId { get; set; }

    public int CommandeId { get; set; }

    public string CommandeNumero { get; set; } = null!;

    public int CommandeNombrePiece { get; set; }
}
