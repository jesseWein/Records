// See https://aka.ms/new-console-template for more information

using Records.Model.Models;
using Records.Model.Services;
using static Records.Model.Extensions.PersonSort;
using static Records.Model.Extensions.EnumerablePersonExtensions;

var dataFile1 = "Data1.txt";

var data1 = Parser.ParsePersons(dataFile1,"pipe");
printData(data1);



void printData(IEnumerable<Person> data)
{
    Console.WriteLine(data.AsQueryable().SortByColorThenLastNameAscending().ListToString());
    Console.WriteLine("----");
    Console.WriteLine(data.AsQueryable().SortByBirthdate().ListToString());
    Console.WriteLine("----");
    Console.WriteLine(data.AsQueryable().SortByLastName().ListToString());
    Console.WriteLine("***********");
}