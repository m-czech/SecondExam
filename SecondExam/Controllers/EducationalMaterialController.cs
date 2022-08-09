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
    
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateEducationalMaterial(CreateEducationalMaterialDto newMaterial)
    {
        var materialType = await _repositories.EducationalMaterialType.GetSingleAsync(newMaterial.EducationalMaterialTypeId);
        if (materialType == null)
        {
            return NotFound("Specified material id has not been found");
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
    
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public async Task<IActionResult> GetSingleEducationalMaterial(int id)
    {
        var material = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (material == null) return NotFound($"Specified material id: {id} has not been found");
        return Ok(_mapper.Map<GetEducationalMaterialDto>(material));
    }

    [HttpPatch]
    [Authorize(Roles = "ADMIN")]
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
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteEducationalMaterial(int id)
    {
        var materialToDelete = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (materialToDelete == null) return NotFound($"Specified material id: {id} has not been found");
        _repositories.EducationalMaterial.DeleteEducationalMaterial(materialToDelete);
        await _repositories.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [Route("average")]
    [Authorize(Roles = "ADMIN")]
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

    [HttpGet]
    [Route("type1")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetEducationalMaterialByType(int typeId)
    {
        var materialType = await _repositories.EducationalMaterialType.GetSingleAsync(typeId);
        if (materialType == null) return NotFound($"Specified material id: {typeId} has not been found");

        var materials = await _repositories.EducationalMaterial.GetAllAsync();
        var filteredMaterials = materials.Where(material => material.EducationalMaterialTypeId == typeId);

        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialDto>>(filteredMaterials));
    }
}
