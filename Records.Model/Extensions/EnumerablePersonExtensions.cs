using Records.Model.Models;

namespace Records.Model.Extensions;

public static class EnumerablePersonExtensions
{
    public static string ListToString(this IEnumerable<Person> input)
    {
        var people = input.Select(x => x.ToString());
        return string.Join(Environment.NewLine,people);
    }
}