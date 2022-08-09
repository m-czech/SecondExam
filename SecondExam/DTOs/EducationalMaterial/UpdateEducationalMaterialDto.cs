using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterial;

public class UpdateEducationalMaterialDto
{
    [Required]
    [MaxLength(255)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(255)]
    [DataType(DataType.Url)]
    public string? Location { get; set; }
    [Required]
    [Range(1,10000)]
    public int? EducationalMaterialTypeId { get; set; }
    [Required]
    [Range(1, 10000)]
    public int? AuthorId { get; set; }
}
