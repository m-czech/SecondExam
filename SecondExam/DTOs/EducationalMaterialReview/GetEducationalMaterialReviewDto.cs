using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.EducationalMaterialReview;

public class GetEducationalMaterialReviewDto
{
    [Required]
    [MaxLength(255)]
    public string? TextReview { get; set; }

    [Required]
    [Range(1, 10)]
    public int? DigitReview { get; set; }
}
