using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.Author;

public class GetAuthorDto
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required]
    [MaxLength (255)]
    public string? Description { get; set; }

    [Range(0, 10000)]
    public int? CreatedMaterials { get; set; }
}
