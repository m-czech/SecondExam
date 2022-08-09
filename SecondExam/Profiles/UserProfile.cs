using AutoMapper;
using SecondExam.DTOs.User;
using SecondExam.Entities.Authorization;

namespace SecondExam.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserForRegistrationDto>().ReverseMap();
    }
}
