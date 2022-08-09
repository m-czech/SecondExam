using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.Author;
using SecondExam.Repository.Contracts;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/author")]
public class AuthorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;
    public AuthorController(IRepositoryManager repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    /// Get Author by id
    /// </summary>
    /// <returns>Author</returns>
    /// <response code="200">Author found</response>
    /// <response code="404">Author not found</response>

    [HttpGet]
    [Route("{id}")]
    
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _repository.Author.GetSingleAsync(id);
        if (author == null) return NotFound($"Author with specified id: {id} has not been found");

        return Ok(_mapper.Map<GetAuthorDto>(author));
    }
}
