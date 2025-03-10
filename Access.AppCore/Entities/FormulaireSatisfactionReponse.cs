﻿namespace Access.AppCore.Entities;

public class FormulaireSatisfactionReponse : Bases.EntiteBase<int>
{
    public int FormulaireSatisfactionId { get; set; }

    public int ClientId { get; set; }

    public int FormulaireSatisfactionQuestionId { get; set; }

    public string FormulaireSatisfactionQuestion { get; set; } = null!;

    public string Reponse { get; set; } = null!;
}
