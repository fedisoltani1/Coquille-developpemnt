using System;
using System.Collections.Generic;

namespace Access.AppCore.Entities;

public class InventaireStatut : Bases.EntiteBase<int>
{
    public string Intitule { get; set; } = null!;
}
