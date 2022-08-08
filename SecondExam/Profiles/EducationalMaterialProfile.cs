using AutoMapper;
using SecondExam.DTOs.EducationalMaterial;
using SecondExam.Entities;

namespace SecondExam.Profiles;

public class EducationalMaterialProfile : Profile
{
    public EducationalMaterialProfile()
    {
        CreateMap<EducationalMaterial, CreateEducationalMaterialDto>().ReverseMap();
        CreateMap<EducationalMaterial, GetEducationalMaterialDto>().ReverseMap();
    }
}
