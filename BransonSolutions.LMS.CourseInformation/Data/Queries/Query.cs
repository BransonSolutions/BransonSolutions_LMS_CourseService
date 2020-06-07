using BransonSolutions.LMS.CourseInformation.Data.Repositories;
using BransonSolutions.LMS.CourseInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Data.Queries
{
    public class Query : IQuery
    {
        private readonly IRepository _data;

        public Query(IRepository repository)
        {
            _data = repository;
        }

        public override CourseModel GetCourseInformation()
        {
            return new CourseModel()
            {
                coursesList = _data.GetCourses()
            };
        }
    }
}
