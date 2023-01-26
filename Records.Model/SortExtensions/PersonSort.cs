using Records.Model.Models;

namespace Records.Model.SortExtensions;

public static class PersonSort
{
    public static IQueryable<Person> SortByColorThenLastNameAscending(this IQueryable<Person> input)
    {
        return input.OrderByDescending(x => x.FavoriteColor).ThenBy(x => x.LastName);
    }
    public static IQueryable<Person> SortByBirthdate(this IQueryable<Person> input)
    {
        return input.OrderBy(x => x.DateOfBirth);
    }
    public static IQueryable<Person> SortByLastName(this IQueryable<Person> input)
    {
        return input.OrderByDescending(x => x.LastName);
    }
}