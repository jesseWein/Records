// See https://aka.ms/new-console-template for more information

using Records.Model.Models;
using Records.Model.Services;
using static Records.Model.Extensions.PersonSort;
using static Records.Model.Extensions.EnumerablePersonExtensions;

var dataFile1 = "Data1.txt";
var dataFile2 = "Data2.txt";
var dataFile3 = "Data3.txt";


var data1 = Parser.ParsePersons(dataFile1,"pipe");
printData(data1);

var data2 = Parser.ParsePersons(dataFile2, "comma");
printData(data2);

var data3 = Parser.ParsePersons(dataFile3, "space");
printData(data3);



void printData(IEnumerable<Person> data)
{
    Console.WriteLine(data.AsQueryable().SortByColorThenLastNameAscending().ListToString());
    Console.WriteLine("----");
    Console.WriteLine(data.AsQueryable().SortByBirthdate().ListToString());
    Console.WriteLine("----");
    Console.WriteLine(data.AsQueryable().SortByLastName().ListToString());
    Console.WriteLine("***********");
}