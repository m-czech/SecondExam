using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = "user, admin")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _repository.Author.GetSingleAsync(id);
        if (author == null) return NotFound($"Author with specified id: {id} has not been found");

        return Ok(_mapper.Map<GetAuthorDto>(author));
    }
}
