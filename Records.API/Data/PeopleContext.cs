using Records.Model.Models;

namespace Records.API.Data;

public class PeopleContext
{
    private List<Person> _persons = new List<Person>();

    public List<Person> Persons => _persons;
}