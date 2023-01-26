using Microsoft.AspNetCore.Mvc;
using Records.Model.Models;
using Records.Model.Services;
using static Records.Model.Extensions.PersonSort;
using static Records.Model.Extensions.EnumerablePersonExtensions;

namespace Records.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RecordsController: ControllerBase
{
    private readonly ILogger<RecordsController> _logger;
    //data store
    private List<Person> Persons = new List<Person>();

    public RecordsController(ILogger<RecordsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post([FromBody] string data)
    {
        try
        {
            var newPerson = Parser.ParsePersons(getStream(data), getDataType(data));
            Persons.Add(newPerson.First());
            return Created("",null);
        }
        catch (IndexOutOfRangeException ioe)
        {
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("color")]
    public IEnumerable<Person> GetColor()
    {
        return Persons.AsQueryable().SortByColorThenLastNameAscending();
    }
    
    [HttpGet]
    [Route("birthdate")]
    public IEnumerable<Person> GetBirthdate()
    {
        return Persons.AsQueryable().SortByBirthdate();
    }
    
    [HttpGet]
    [Route("name")]
    public IEnumerable<Person> GetName()
    {
        return Persons.AsQueryable().SortByLastName();
    }

    private string getDataType(string data)
    {
        if (data.Contains("|")) return "pipe";
        if (data.Contains(",")) return "comma";
        return "space";
    }
    private Stream getStream(string data)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(data);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}