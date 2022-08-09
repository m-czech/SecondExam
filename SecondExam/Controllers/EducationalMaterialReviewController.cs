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

    /// <summary>
    /// Get Review by id
    /// </summary>
    /// <returns>Review Type</returns>
    /// <response code="200">Found Review</response>
    /// <response code="404">Not Found Review</response>

    [HttpGet]
    [Authorize(Roles = "user, admin")]
    [Route("{id}", Name = "ReviewById")]
    public async Task<IActionResult> GetReviews(int materialId)
    {
        var material = await _repository.EducationalMaterial.GetSingleAsync(materialId);
        if (material.Reviews == null) return NotFound($"Material with specified id: {materialId} does not have any review");

        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialReviewDto>>(material.Reviews));
    }

    /// <summary>
    /// Create new educational material review
    /// </summary>
    /// <returns>Location to new resource</returns>
    /// <response code="201">Created new review</response>
    /// <response code="404">Educational material not found</response>

    [HttpPost]
    [Authorize(Roles = "user, admin")]
    public async Task<IActionResult> CreateReview(CreateEducationalMaterialReviewDto newReview, int materialId)
    {
        var material = await _repository.EducationalMaterial.GetSingleAsync(materialId);
        if (material == null) return NotFound($"Material with specified id: {materialId} has not been found");

        var review = _mapper.Map<EducationalMaterialReview>(newReview);
        if (material.Reviews == null) material.Reviews = new List<EducationalMaterialReview>() { review };
        else material.Reviews.Add(review);

        await _repository.SaveAsync();
        return CreatedAtRoute("ReviewById", new { id = material.Id }, material);
    }

    /// <summary>
    /// Delete review with spiecified id
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Review removed</response>
    /// <response code="404">Review not found</response>

    [HttpDelete]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        var review = await _repository.Review.GetSingleByConditionAsync(review => review.Id == reviewId);
        if (review == null) return NotFound($"Review with specified id: {reviewId} has not been found");

        _repository.Review.DeleteEducationalMaterialReview(review);
        await _repository.SaveAsync();

        return NoContent();
    }

    /// <summary>
    /// Update review
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "textReview": "New text review",
    ///        "digitReview": 10
    ///     }
    ///
    /// </remarks>
    /// <response code="204">No content</response>
    /// <response code="404">Review not found</response>

    [HttpPatch]
    [Authorize(Roles = "user, admin")]
    public async Task<IActionResult> UpdateReview(UpdateEducationalMaterialReviewDto updatedReview, int reviewId)
    {
        var review = await _repository.Review.GetSingleByConditionAsync(review => review.Id == reviewId);
        if (review == null) return NotFound($"Review with specified id: {reviewId} has not been found");

        review.DigitReview = updatedReview.DigitReview;
        review.TextReview = updatedReview.TextReview;

        await _repository.SaveAsync();
        return NoContent();
    }
}
