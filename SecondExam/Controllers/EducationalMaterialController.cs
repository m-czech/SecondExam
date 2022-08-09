using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.EducationalMaterial;
using SecondExam.Entities;
using SecondExam.Repository.Contracts;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/material")]
public class EducationalMaterialController : ControllerBase
{
    private readonly IRepositoryManager _repositories;
    private readonly IMapper _mapper;
    public EducationalMaterialController(IRepositoryManager repositories, IMapper mapper)
    {
        _repositories = repositories;
        _mapper = mapper;
    }

    /// <summary>
    /// Create new educational material
    /// </summary>
    /// <returns>Location to new resource</returns>
    /// <response code="204">Created new educational material</response>
    /// <response code="404">Educational material type not found</response>
    /// <response code="404">Author not found</response>

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateEducationalMaterial(CreateEducationalMaterialDto newMaterial)
    {
        var materialType = await _repositories.EducationalMaterialType.GetSingleAsync(newMaterial.EducationalMaterialTypeId);
        if (materialType == null)
        {
            return NotFound("Specified material type id has not been found");
        }

        var author = await _repositories.Author.GetSingleAsync(newMaterial.AuthorId);
        if (author == null)
        {
            return NotFound("Specified author id has not been found!");
        }

        var materialEntity = _mapper.Map<EducationalMaterial>(newMaterial);
        materialEntity.EducationalMaterialType = materialType;
        _repositories.EducationalMaterial.CreateEducationalMaterial(materialEntity);
        await _repositories.SaveAsync();
        return NoContent();
    }

    /// <summary>
    /// Get Educational Material by id
    /// </summary>
    /// <returns>Educational Material</returns>
    /// <response code="200">Educational Material</response>
    /// <response code="404">Educational material not found</response>

    [HttpGet]
    [Authorize(Roles = "user, admin")]
    public async Task<IActionResult> GetSingleEducationalMaterial(int id)
    {
        var material = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (material == null) return NotFound($"Specified material id: {id} has not been found");
        return Ok(_mapper.Map<GetEducationalMaterialDto>(material));
    }

    /// <summary>
    /// Update Educational Material
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "title": "New title",
    ///        "description": "New description",
    ///        "location": "Educational Material resource location",
    ///        "educationalMaterialTypeId": 2,
    ///        "authorId": 3
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Educational Material has been updated</response>
    /// <response code="404">Educational Material not found</response>

    [HttpPatch]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateEducationalMaterial(int id, UpdateEducationalMaterialDto updatedMaterial)
    {
        var materialToUpdate = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (materialToUpdate == null) return NotFound($"Specified material id: {id} has not been found");
        materialToUpdate.AuthorId = updatedMaterial.AuthorId;
        materialToUpdate.Description = updatedMaterial.Description;
        materialToUpdate.Location = updatedMaterial.Location;
        materialToUpdate.EducationalMaterialTypeId = updatedMaterial.EducationalMaterialTypeId;
        materialToUpdate.Title = updatedMaterial.Title;
        await _repositories.SaveAsync();
        return NoContent();
    }

    /// <summary>
    /// Delete Educational Material with specified id
    /// </summary>
    /// <response code="204">Educational Material removed</response>
    /// <response code="404">Educational Material not found</response>

    [HttpDelete]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteEducationalMaterial(int id)
    {
        var materialToDelete = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (materialToDelete == null) return NotFound($"Specified material id: {id} has not been found");
        _repositories.EducationalMaterial.DeleteEducationalMaterial(materialToDelete);
        await _repositories.SaveAsync();
        return NoContent();
    }

    /// <summary>
    /// Get Educational Material for given author with average above five
    /// </summary>
    /// <returns>Educational Material</returns>
    /// <response code="200">Educational Materials</response>

    [HttpGet]
    [Route("average")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetEducationalMaterialsForGivenAuthorWithAverageReviewsAboveFive(int authorId)
    {
        var fetchedMaterials = await _repositories.EducationalMaterial.GetAllAsync();
        var materialsFilteredByAuthor = fetchedMaterials.Where(material => material.AuthorId == authorId);
        var materialsFilteredByAuthorAndRating = new List<EducationalMaterial>();
        foreach (var material in materialsFilteredByAuthor)
        {
            float reviewSum = 0;
            if (material.Reviews == null) break;
            material.Reviews.ToList().ForEach(review => reviewSum += (float)review.DigitReview!);
            var average = reviewSum = reviewSum / material.Reviews.Count();
            if (average > 5) materialsFilteredByAuthorAndRating.Add(material);
        }
        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialDto>>(materialsFilteredByAuthorAndRating));
    }

    /// <summary>
    /// Get Educational Material by type
    /// </summary>
    /// <returns>Educational Material</returns>
    /// <response code="200">Educational materials</response>
    /// <response code="404">Educational material type not found</response>
    /// 
    [HttpGet]
    [Route("type")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetEducationalMaterialByType(int typeId)
    {
        var materialType = await _repositories.EducationalMaterialType.GetSingleAsync(typeId);
        if (materialType == null) return NotFound($"Specified material type id: {typeId} has not been found");

        var materials = await _repositories.EducationalMaterial.GetAllAsync();
        var filteredMaterials = materials.Where(material => material.EducationalMaterialTypeId == typeId);

        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialDto>>(filteredMaterials));
    }
}
