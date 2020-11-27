using System.Collections.Generic;

namespace BransonSolutions.LMS.CourseInformation.Domain
{
    public class Course
    {
        public string name { get; set; }
        public string instructor { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public List<Video> videos { get; set; }
    }
}
