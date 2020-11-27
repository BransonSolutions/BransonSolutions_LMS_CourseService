using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using BransonSolutions.LMS.CourseInformation.Configuration;
using BransonSolutions.LMS.CourseInformation.Data.Queries;
using BransonSolutions.LMS.CourseInformation.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BransonSolutions.LMS.CourseInformation
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Console.WriteLine($"starting BransonSolutions.LMS.Course service. Environment = {environment.EnvironmentName}");
            ConfigurationBuilder builder = (ConfigurationBuilder) new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfiguration Configuration { get; private set; }
        public static IWebHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAWSService<IAmazonDynamoDB>();

            services.AddSingleton(GetDbConfiguration());

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IQuery, Query>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static DbConfiguration GetDbConfiguration()
        {
            DbConfiguration dbConf = new DbConfiguration()
            {
                ServiceURL = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBServiceURLKey),
                TableName = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBTableNameKey)
            };
            return dbConf;
        }
    }
}
