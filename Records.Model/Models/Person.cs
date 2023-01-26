namespace Records.Model.Models;

public class Person
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string FavoriteColor { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public override string ToString()
    {
        return $"{LastName},{FirstName},{Email},{FavoriteColor},{DateOfBirth?.ToString("M/d/yyyy")}";
    }
}
