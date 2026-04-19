using System;

namespace introduction_to_json_warrenh123.Models
{
    public class SchoolTerm
    {
        public DateTime Start{ get; private set; }
        public DateTime End{ get; private set; }
        public DateTime HalfTermStarts{ get; private set; }
        public DateTime HalfTermEnds{ get; private set; }
    }
}