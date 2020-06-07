using BransonSolutions.LMS.CourseInformation.Data.Repositories;
using BransonSolutions.LMS.CourseInformation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BransonSolutions.LMS.CourseInformation.Test.Mocks
{
    public class MockRepository : IRepository
    {
        public override List<Course> GetCourses()
        {
            List<Course> courseList = new List<Course>();
            courseList.Add(new Course()
            {
                title = "Babys First Course"
            });
            courseList.Add(new Course()
            {
                title = "Babys Second Course"
            });
            return courseList;
        }
    }
}
