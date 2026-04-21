using System;
using System.IO;
using System.Text.Json;
using introduction_to_json_warrenh123.Models;
using System.Collections.Generic;


namespace introduction_to_json_warrenh123
{
    public class CalendarService
    {
        public Dictionary<string, Dictionary<string, SchoolTerm>> AcademicYears{ get; private set; } = new Dictionary<string, Dictionary<string, SchoolTerm>>();

        public void LoadData(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<SchoolCalendar>(jsonString);
            AcademicYears = result.academic_years; 
        }

        public string CountDown()
        {
            DateTime today = DateTime.Today;

            foreach(KeyValuePair<string, Dictionary<string, SchoolTerm>> year in AcademicYears)
            {
                foreach(KeyValuePair<string, SchoolTerm> term in year.Value)
                {
                    if(term.Value.Start <= today && term.Value.End >= today)//see which term user is in
                    {                    
                        if(today < term.Value.half_term_start) // First half term
                        {
                            int days = (term.Value.half_term_start - today).Days;
                            string termName = term.Key.Replace("_", " ");
                            if(days == 1)
                            {
                                return $"You are in {termName} - {days} day until end of first half term.";
                            }
                            else
                            {
                                return $"You are in {termName} - {days} days until end of first half term.";
                            }
                            
                        }
                        if(today >= term.Value.half_term_start && today <= term.Value.half_term_end) //in half term holiday
                        {
                            int days = (term.Value.half_term_end - today).Days;
                            if(days == 1)
                            {
                                return $"You are in half term break - {days} day until end of holiday.";
                            }
                            else
                            {
                                return $"You are in half term break - {days} days until end of holiday.";
                            }
                        }
                        else //Second half term
                        {
                            int days = (term.Value.End - today).Days;
                            string termName = term.Key.Replace("_", " ");
                            if(days == 1)
                            {
                                return $"You are in {termName} - {days} day until the end of the second half term.";
                            }
                            else
                            {
                                return $"You are in {termName} - {days} days until the end of the second half term.";
                            }
                        }
                    }
                }
            }
            return "Not in a term or in a holiday";
        }
    
    public string KeyDateSummary()
        {
            DateTime today = DateTime.Today;
            var upcoming = new List<(int days, string name, DateTime start, DateTime end)>(); // list of tuples

            foreach (KeyValuePair<string, Dictionary<string, SchoolTerm>> year in AcademicYears)
            {
                foreach (KeyValuePair<string, SchoolTerm> term in year.Value)
                {
                    string termName = term.Key.Replace("_", " ");
                    SchoolTerm t = term.Value;

                    // half-term break
                    if (t.half_term_end >= today)
                        upcoming.Add(((t.half_term_start - today).Days, $"{termName} Half-Term", t.half_term_start, t.half_term_end));

                    // end of term
                    if (t.End >= today)
                        upcoming.Add(((t.End - today).Days, $"End of {termName}", t.End, t.End));

                    // start of term
                    if (t.Start >= today)
                        upcoming.Add(((t.Start - today).Days, $"Start of {termName}", t.Start, t.Start));
                }
            }
            for (int i = 0; i < upcoming.Count - 1; i++) //bubble sort for date
            {
                for (int j = 0; j < upcoming.Count - 1 - i; j++)
                {
                    if (upcoming[j].days > upcoming[j + 1].days)
                    {
                        var temp = upcoming[j];
                        upcoming[j] = upcoming[j + 1];
                        upcoming[j + 1] = temp;
                    }
                }
            }

            string result = "  -------------- Key Date Summary ---------------\n";
            foreach (var (days, name, start, end) in upcoming)
            {
                string range;
                if (start == end)
                {
                    range = start.ToString("d MMM yyyy");
                }
                else
                {
                    range = start.ToString("d MMM") + " - " + end.ToString("d MMM yyyy");
                }
                result += $"  {days,4}d   {name,-35} {range}\n";
            }
            return result;
        }
    }
}