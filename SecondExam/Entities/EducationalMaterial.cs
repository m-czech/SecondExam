using System.ComponentModel.DataAnnotations.Schema;

namespace SecondExam.Entities;

public class EducationalMaterial
{
    public int Id { get; set; }
    public Author? Author { get; set; }
    public int? AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int? EducationalMaterialTypeId { get; set; }
    public EducationalMaterialType? EducationalMaterialType { get; set; }
    [ForeignKey("ReviewedMaterialId")]
    public ICollection<EducationalMaterialReview>? Reviews { get; set; }
    public DateTime? PublicationDate { get; set; }
}
