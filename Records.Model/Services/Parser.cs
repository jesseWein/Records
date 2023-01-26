using Microsoft.VisualBasic.FileIO;
using Records.Model.Models;

namespace Records.Model.Services;

public static class Parser
{
    public static IEnumerable<Person> ParsePersons(string Filename, string type)
    {
        List<Person> Results = new List<Person>();
        using (TextFieldParser parser = new TextFieldParser(Filename))
        {
            parser.TextFieldType = FieldType.Delimited;
            switch (type)
            {
                case "pipe":
                    parser.SetDelimiters("|");
                    break;
                
                case "space":
                    parser.SetDelimiters(" ");
                    break;
                case "comma":
                default:
                    parser.SetDelimiters(",");
                    break;
            }

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                Results.Add(new Person()
                {
                    LastName = fields[0],
                    FirstName = fields[1],
                    Email = fields[2],
                    FavoriteColor = fields[3],
                    DateOfBirth = DateTime.TryParse(fields[4],out DateTime dt)?dt:null
                });
            }

            return Results;
        }
    }
}