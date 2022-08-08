namespace SecondExam.Entities;

public class EducationalMaterial
{
    public int Id { get; set; }
    public Author? Author { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public EducationalMaterialType? Type { get; set; }
    IEnumerable<EducationalMaterialReview>? Reviews { get; set; }
    DateTime? PublishingDate { get; set; }
}
