using System.Collections.Generic;
using introduction_to_json_warrenh123.Models;

namespace introduction_to_json_warrenh123.Models
{
    public class SchoolYear
    {
        public string Name{ get; private set; }
        public Dictionary<string, SchoolTerm> Terms{ get; private set;} = new Dictionary<string, SchoolTerm>();


    }
}