using System.ComponentModel.DataAnnotations;

namespace SecondExam.DTOs.User;

public class UserForRegistrationDto
{
    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(100)]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    [Required]
    public ICollection<string>? Roles { get; set; }
}
