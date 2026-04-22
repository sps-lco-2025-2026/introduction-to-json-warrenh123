using introduction_to_json_warrenh123;

CalendarService service = new CalendarService();

string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SchoolDates.json");
service.LoadData(path);

Console.WriteLine(service.CountDown());
Console.WriteLine();
Console.WriteLine(service.KeyDateSummary());