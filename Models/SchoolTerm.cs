using System;
using System.Text.Json.Serialization;

namespace introduction_to_json_warrenh123.Models
{
    public class SchoolTerm
    {
        [JsonPropertyName("start")]
        public DateTime Start{ get; set; }

        [JsonPropertyName("end")]
        public DateTime End{ get; set; }

        [JsonPropertyName("half_term_start")]
        public DateTime half_term_start{ get; set; }

        [JsonPropertyName("half_term_end")]
        public DateTime half_term_end{ get; set; }
    }
}