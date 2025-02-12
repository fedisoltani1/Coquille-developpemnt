namespace Access.AppCore.Entities;

public class FormulaireSatisfactionQuestion
{
    public int Id { get; set; }

    public int FormulaireSatisfactionId { get; set; }

    public string Question { get; set; } = null!;

    public int FormulaireSatisfactionQuestionTypeId { get; set; }
}
