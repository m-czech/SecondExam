using SecondExam.DTOs.EducationalMaterialType;
using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterial;

public record CreateEducationalMaterialDto
{
    [Required]
    [MaxLength(255)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Location { get; set; }
    [Required]
    [Range(1, 100000)]
    public int EducationalMaterialTypeId { get; set; }

    [Required]
    [Range(1, 100000)]
    public int AuthorId { get; set; }
}
