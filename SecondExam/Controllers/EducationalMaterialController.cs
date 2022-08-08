using Microsoft.AspNetCore.Mvc;
using SecondExam.Repository.Contracts;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/material")]
public class EducationalMaterialController : ControllerBase
{
    private readonly IRepositoryManager _repositories;
    public EducationalMaterialController(IRepositoryManager repositories)
    {
        _repositories = repositories;
    }

}
