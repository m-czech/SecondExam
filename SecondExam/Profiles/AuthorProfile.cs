using AutoMapper;
using SecondExam.DTOs.Author;
using SecondExam.Entities;

namespace SecondExam.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, GetAuthorDto>().ReverseMap();
    }
}
