using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterialType;

public record EducationalMaterialTypeDto
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }
}
