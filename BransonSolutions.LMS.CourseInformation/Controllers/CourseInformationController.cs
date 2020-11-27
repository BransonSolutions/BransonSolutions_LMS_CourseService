using System;
using System.Collections.Generic;
using BransonSolutions.LMS.CourseInformation.Data.Queries;
using BransonSolutions.LMS.CourseInformation.Data.Repositories;
using BransonSolutions.LMS.CourseInformation.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BransonSolutions.LMS.CourseInformation.Controllers
{
    [Route("api/v1/[controller]")]
    public class CourseInformationController : ControllerBase
    {
        private IQuery _queryService;

        public CourseInformationController(IQuery queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            Console.WriteLine("about to query for info");
            return _queryService.GetCourseInformation().coursesList;
        }

    }
}
