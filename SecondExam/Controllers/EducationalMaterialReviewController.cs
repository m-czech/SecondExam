using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.EducationalMaterialReview;
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

    [HttpGet]
    public async Task<IActionResult> GetReviews(int materialId)
    {
        var material = await _repository.EducationalMaterial.GetSingleAsync(materialId);
        if (material.Reviews == null) return NotFound($"Material with specified id: {materialId} does not have any review");

        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialReviewDto>>(material.Reviews));
    }
}
