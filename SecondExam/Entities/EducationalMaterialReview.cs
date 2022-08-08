namespace SecondExam.Entities;

public class EducationalMaterialReview
{
    public int Id { get; set; }
    public EducationalMaterial? ReviewedMaterial { get; set; }
    public string? TextReview { get; set; }
    public int? DigitReview { get; set; }
}
