namespace Access.AppCore.Entities;

public class FormulaireSatisfactionQuestion : Bases.EntiteBase<int>
{
    public int FormulaireSatisfactionId { get; set; }

    public string Question { get; set; } = null!;

    public int FormulaireSatisfactionQuestionTypeId { get; set; }
}
