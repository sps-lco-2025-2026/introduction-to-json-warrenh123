using introduction_to_json_warrenh123;

CalendarService service = new CalendarService();

service.LoadData(@"C:\Users\warre\OneDrive\Desktop\Coding\Csharp-work\School work\Class work\introduction-to-json-warrenh123\Data\SchoolDates.json");

Console.WriteLine(service.CountDown());