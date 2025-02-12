using System;
using System.Collections.Generic;

namespace Access.AppCore.Entities;

public class InventaireScan
{
    public int Id { get; set; }

    public int InventaireId { get; set; }

    public int CommandeId { get; set; }

    public string CommandeNumero { get; set; } = null!;

    public int CommandeNombrePiece { get; set; }

    public int CollaborateurId { get; set; }

    public DateTime DateScan { get; set; }
}
