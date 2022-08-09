using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.EducationalMaterialReview;
using SecondExam.Entities;
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
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> GetReviews(int materialId)
    {
        var material = await _repository.EducationalMaterial.GetSingleAsync(materialId);
        if (material.Reviews == null) return NotFound($"Material with specified id: {materialId} does not have any review");

        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialReviewDto>>(material.Reviews));
    }

    [HttpPost]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> CreateReview(CreateEducationalMaterialReviewDto newReview, int materialId)
    {
        var material = await _repository.EducationalMaterial.GetSingleAsync(materialId);
        if (material == null) return NotFound($"Material with specified id: {materialId} has not been found");

        var review = _mapper.Map<EducationalMaterialReview>(newReview);
        if (material.Reviews == null) material.Reviews = new List<EducationalMaterialReview>() { review };
        else material.Reviews.Add(review);

        await _repository.SaveAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        var review = await _repository.Review.GetSingleByConditionAsync(review => review.Id == reviewId);
        if (review == null) return NotFound($"Review with specified id: {reviewId} has not been found");

        _repository.Review.DeleteEducationalMaterialReview(review);
        await _repository.SaveAsync();

        return NoContent();
    }

    [HttpPatch]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> UpdateReview(UpdateEducationalMaterialReviewDto updatedReview, int reviewId)
    {
        var review = await _repository.Review.GetSingleByConditionAsync(review => review.Id == reviewId);
        if (review == null) return NotFound($"Review with specified id: {reviewId} has not been found");

        review.DigitReview = updatedReview.DigitReview;
        review.TextReview = updatedReview.TextReview;

        await _repository.SaveAsync();
        return Ok();
    }
}
