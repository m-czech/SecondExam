using AutoMapper;
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
    public async Task<IActionResult> CreateEducationalMaterial(CreateEducationalMaterialDto newMaterial)
    {
        var materialType = await _repositories.EducationalMaterialType.GetSingleAsync(newMaterial.EducationalMaterialTypeId);
        if (materialType == null)
        {
            return NotFound("Specified material id has not been found");
        }

        var author = await _repositories.Author.GetSingle(newMaterial.AuthorId);
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
    public async Task<IActionResult> GetSingleEducationalMaterial(int id)
    {
        var material = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (material == null) return NotFound($"Specified material id: {id} has not been found");
        return Ok(_mapper.Map<GetEducationalMaterialDto>(material));
    }

    [HttpPatch]
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
    public async Task<IActionResult> DeleteEducationalMaterial(int id)
    {
        var materialToDelete = await _repositories.EducationalMaterial.GetSingleAsync(id);
        if (materialToDelete == null) return NotFound($"Specified material id: {id} has not been found");
        _repositories.EducationalMaterial.DeleteEducationalMaterial(materialToDelete);
        await _repositories.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [Route("hihi")]
    public async Task<IActionResult> GetMaterialsForGivenAuthor(int id)
    {
        var fetchedAuthors = await _repositories.Author.GetSingle(id);
        if (fetchedAuthors == null) return NotFound();
        if (fetchedAuthors.Materials == null) return NotFound();
        
        return Ok(_mapper.Map<IEnumerable<GetEducationalMaterialDto>>(fetchedAuthors.Materials));
    }
}
