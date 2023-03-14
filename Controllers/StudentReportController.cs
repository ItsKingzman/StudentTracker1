using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentTracker1.Context;

namespace StudentTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentReportController : ControllerBase
    {
        private readonly static List<StudentReport> list = new List<StudentReport>()
            {
                new StudentReport() { Name = "Beth", Course = "English", Grade = 98 },
                new StudentReport() { Name = "Allen", Course = "Science", Grade = 83 },
                new StudentReport() { Name = "Greg", Course = "Math", Grade = 80 },
                new StudentReport() { Name = "Bob", Course = "Art", Grade = 92 },
                new StudentReport() { Name = "Jane", Course = "History", Grade = 90 },
                new StudentReport() { Name = "John", Course = "Quantum Physics", Grade = 88 },
            };

        private readonly ILogger<StudentReportController> _logger;
        public StudentReportController(ILogger<StudentReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentReport> Get()
        {
            try
            {
                return list;
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when retrieving student reports");

                // Return a 500 response
                return (IEnumerable<StudentReport>)StatusCode(500);
            }
        }

        [HttpGet("{name}")]
        public StudentReport GetStudentReport(string name)
        {
            try
            {
                return list.Where(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when retrieving student report for {name}", name);

                // Return a 500 response
                return (StudentReport)(IEnumerable<StudentReport>)StatusCode(500);
            }
        }

        [HttpPost]
        public void AddStudentReport([FromBody] StudentReport studentReport)
        {
            try
            {
                list.Add(studentReport);
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when adding student report");
            }
        }

        [HttpPut("{name}")]
        public void UpdateStudentReport(string name, StudentReport studentReport)
        {
            try
            {
                var existingStudentReport = list.Where(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (existingStudentReport != null)
                {
                    existingStudentReport.Course = studentReport.Course;
                    existingStudentReport.Grade = studentReport.Grade;
                }
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when updating student report for {name}", name);
            }
        }

        [HttpDelete("{name}")]
        public void DeleteStudentReport(string name)
        {
            try
            {
                var existingStudentReport = list.Where(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (existingStudentReport != null)
                {
                    list.Remove(existingStudentReport);
                }
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when deleting student report for {name}", name);
            }
        }

        [HttpGet("StudentsByCourse")]
        public IEnumerable<StudentReport> GetStudentReportsByCourse(string course)
        {
            return list.Where(s => string.Equals(s.Course, course, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}