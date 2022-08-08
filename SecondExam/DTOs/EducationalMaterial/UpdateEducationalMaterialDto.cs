using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterial;

public class UpdateEducationalMaterialDto
{
    [MaxLength(255)]
    public string? Title { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }
    [MaxLength(255)]
    public string? Location { get; set; }
    public int? EducationalMaterialTypeId { get; set; }

    public int? AuthorId { get; set; }
}
