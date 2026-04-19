using System;
using System.IO;
using System.Text.Json;
using introduction_to_json_warrenh123.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace introduction_to_json_warrenh123
{
    public class CalendarService
    {
        public Dictionary<string, SchoolYear> AcademicYear{ get; private set; } = new Dictionary<string, SchoolYear>();


        public void LoadData(string filePath)
        {
            string jsonString;
            File.ReadAllText(filePath);
            
        }
    }


}