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
            return NotFound("Material type with specified id has not been found!");
        }

        
        var materialEntity = _mapper.Map<EducationalMaterial>(newMaterial);
        materialEntity.EducationalMaterialType = materialType;
        _repositories.EducationalMaterial.CreateEducationalMaterial(materialEntity);
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
