using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BransonSolutions.LMS.CourseInformation.Data.Queries;
using BransonSolutions.LMS.CourseInformation.Data.Repositories;
using BransonSolutions.LMS.CourseInformation.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BransonSolutions.LMS.CourseInformation.Controllers
{
    [Route("api/[controller]")]
    public class CourseInformationController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            Repository dataRepository = new Repository();
            Query query = new Query(dataRepository);
            return query.GetCourseInformation().coursesList;
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

    }
}
