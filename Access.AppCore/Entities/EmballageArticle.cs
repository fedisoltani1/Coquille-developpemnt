﻿namespace Access.AppCore.Entities;

public class EmballageArticle : Bases.EntiteBase<int>
{
    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }
}
