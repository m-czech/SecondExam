using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterial;

public class GetEducationalMaterialDto
{
    [Required]
    [MaxLength(255)]
    public string? Title { get; set; }
    [Required]
    [MaxLength (255)]
    public string? Description { get; set; }
    [Required]
    [DataType(DataType.Url)]
    public string? Location { get; set; }
}
