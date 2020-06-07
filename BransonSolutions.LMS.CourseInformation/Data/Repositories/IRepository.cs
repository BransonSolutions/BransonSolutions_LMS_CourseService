using BransonSolutions.LMS.CourseInformation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Data.Repositories
{
    public abstract class IRepository
    {
        public abstract List<Course> GetCourses();
    }
}
