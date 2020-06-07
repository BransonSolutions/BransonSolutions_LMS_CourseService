using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Domain
{
    public class Course
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<Video> videos { get; set; }
    }
}
