using AutoMapper;
using SecondExam.DTOs.EducationalMaterialReview;
using SecondExam.Entities;

namespace SecondExam.Profiles;

public class EducationalMaterialReviewProfile : Profile
{
    public EducationalMaterialReviewProfile()
    {
        CreateMap<EducationalMaterialReview, GetEducationalMaterialReviewDto>().ReverseMap();
    }
}
