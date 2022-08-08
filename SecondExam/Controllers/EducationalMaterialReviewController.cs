using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondExam.Repository;
using SecondExam.Repository.Contracts;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/review")]
public class EducationalMaterialReviewController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public EducationalMaterialReviewController(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

}
