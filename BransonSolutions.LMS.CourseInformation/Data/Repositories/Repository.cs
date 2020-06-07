using BransonSolutions.LMS.CourseInformation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Data.Repositories
{
    public class Repository : IRepository
    {
        public override List<Course> GetCourses()
        {
            // TODO: actually get course information
            List<Course> courses = new List<Course>();
            courses.Add(new Course
            {
                title = "this is a course",
                description = "course information goes here",
                videos = new List<Video>()
            });
            return courses;
        }
    }
}
