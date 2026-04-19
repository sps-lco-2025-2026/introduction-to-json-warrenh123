using System.Collections.Generic;
using introduction_to_json_warrenh123.Models;

namespace introduction_to_json_warrenh123.Models
{
    public class SchoolCalendar
    {
        public Dictionary<string, Dictionary<string, SchoolTerm>> academic_years { get; set; } = new Dictionary<string, Dictionary<string, SchoolTerm>>();
    }
}