using System;
using System.IO;
using System.Text.Json;

string jsonFile = File.ReadAllText("termDates.txt");

public var doc = JsonDocument.Parse(jsonFile);
var root = doc.RootElement;

// Dictionary to keep key dates
Dictionary <string,DateOnly>  termStartDates = new Dictionary<string, DateOnly>();
Dictionary <string,DateOnly>  termEndDates = new Dictionary<string, DateOnly>();

var years = root.GetProperty("academic_years");

foreach (var year in years.EnumerateObject())
{
    string schoolYear = year.Name;
    string startingYear = schoolYear.Split('-')[0];

    foreach(var term in year.Value.EnumerateObject())
    {
        string termName = term.Name.Replace('_',' ');

        string s = $"{termName} {startingYear}";

        string startDate = term.Value.GetProperty("start").GetString();

        termStartDates[s] = DateOnly.Parse(startDate);
    }
}

foreach (var item in termStartDates)
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}
