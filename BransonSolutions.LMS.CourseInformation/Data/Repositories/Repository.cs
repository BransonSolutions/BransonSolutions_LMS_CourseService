using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using BransonSolutions.LMS.CourseInformation.Configuration;
using BransonSolutions.LMS.CourseInformation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BransonSolutions.LMS.CourseInformation.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly string _dynamoDbServiceUrl;
        private readonly string _dynamoDbTableName;

        public Repository(DbConfiguration dbConf)
        {
            _dynamoDbServiceUrl = dbConf.ServiceURL;
            _dynamoDbTableName = dbConf.TableName;
        }
        //public override List<Course> GetCourses()
        //{
        //    // TODO: actually get course information
        //    List<Course> courses = new List<Course>();
        //    courses.Add(new Course
        //    {
        //        name = "this is a course",
        //        description = "course information goes here",
        //        videos = new List<Video>()
        //    });
        //    return courses;
        //}

        public override List<Course> GetCourses()
        {
            Console.WriteLine("In the repository code");

            List<Course> courses = new List<Course>();

            AmazonDynamoDBClient client;

            if (!String.IsNullOrEmpty(_dynamoDbServiceUrl))
            {
                AmazonDynamoDBConfig ddbConfig = new AmazonDynamoDBConfig()
                {
                    ServiceURL = _dynamoDbServiceUrl
                };
                client = new AmazonDynamoDBClient(ddbConfig);
            }
            else
            {
                client = new AmazonDynamoDBClient();
            }


            var request = new ScanRequest
            {
                TableName = _dynamoDbTableName,
            };

            var response = client.ScanAsync(request);
            var result = response.Result;

            foreach (Dictionary<string, AttributeValue> item in result.Items)
            {
                Course course = new Course()
                {
                    name = item["name"].S,
                    category = item["category"].S,
                    instructor = item["instructor"].S,
                    description = item["description"].S
                };
                courses.Add(course);
            }

            return courses;

        }
    }
}
