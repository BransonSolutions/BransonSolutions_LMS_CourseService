using BransonSolutions.LMS.CourseInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Data.Queries
{
    public abstract class IQuery
    {
        public abstract CourseModel GetCourseInformation();
    }
}
