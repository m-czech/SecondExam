using AutoMapper;
using SecondExam.DTOs.EducationalMaterialType;
using SecondExam.Entities;

namespace SecondExam.Profiles;

public class EducationalMaterialTypeProfile : Profile
{
    public EducationalMaterialTypeProfile()
    {
        CreateMap<EducationalMaterialType, EducationalMaterialTypeDto>().ReverseMap();
    }
}
