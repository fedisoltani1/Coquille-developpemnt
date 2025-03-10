﻿namespace Access.AppCore.Entities;

public class ClientContact : Bases.EntiteBase<int>
{
    public int ClientId { get; set; }

    public string NomComplet { get; set; } = null!;

    public string Fonction { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? AdresseMail { get; set; }

    public string? Note { get; set; }

    public virtual Client Client { get; set; } = null!;
}
