using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.EducationalMaterialType;
using SecondExam.Entities;
using SecondExam.Repository;
using SecondExam.Repository.Contracts;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/type")]
public class EducationalMaterialTypeController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public EducationalMaterialTypeController(IRepositoryManager repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    /// Get Educational Material Type by id
    /// </summary>
    /// <returns>Educational Material Type</returns>
    /// <response code="200">Found Educational Material Type</response>
    /// <response code="404">Not Found Educational Material Type</response>
    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetSingleAsync(int id)
    {
        var materialType =  await _repository.EducationalMaterialType.GetSingleAsync(id);
        if (materialType == null) NotFound($"Material with specified id: {id} has not been found");

        return Ok(_mapper.Map<EducationalMaterialTypeDto>(materialType));
    }
}
