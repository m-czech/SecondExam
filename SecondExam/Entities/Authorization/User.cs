using Microsoft.AspNetCore.Identity;

namespace SecondExam.Entities.Authorization;

public class User : IdentityUser
{
    public string UserName { get; set; }
}
