using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.User;

public class UserForAuthenticationDto
{
    [Required]
    [MaxLength(100)]
    public string? UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
