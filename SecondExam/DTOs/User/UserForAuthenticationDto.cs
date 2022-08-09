using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.User;

public class UserForAuthenticationDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}
