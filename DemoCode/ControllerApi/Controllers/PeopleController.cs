using Microsoft.AspNetCore.Mvc;
using People.Service;

namespace ControllerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;

    public PeopleController(ILogger<PeopleController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPeople")]
    public async Task<IEnumerable<Person>> Get([FromServices] IPeopleProvider provider)
    {
        return await provider.GetPeople();
    }

    [HttpGet("{id}", Name = "GetPerson")]
    public async Task<Person?> GetPerson([FromServices] IPeopleProvider provider, int id)
    {
        // This may return null
        return await provider.GetPerson(id);
    }
}
