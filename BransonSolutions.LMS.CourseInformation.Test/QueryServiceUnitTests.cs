using BransonSolutions.LMS.CourseInformation.Data.Queries;
using BransonSolutions.LMS.CourseInformation.Models;
using BransonSolutions.LMS.CourseInformation.Test.Mocks;
using NuGet.Frameworks;
using System;
using System.Linq;
using Xunit;

namespace BransonSolutions.LMS.CourseInformation.Test
{
    public class QueryServiceUnitTests
    {
        [Fact]
        public void TestGetCoursesQuery()
        {
            MockRepository courseRepository = new MockRepository();
            Query queryService = new Query(courseRepository);
            CourseModel allCourseData = queryService.GetCourseInformation();
            Assert.Equal("Babys First Course", allCourseData.coursesList.FirstOrDefault(course => course.title == "Babys First Course").title);
        }
    }
}
