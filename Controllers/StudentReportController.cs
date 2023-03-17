using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentTracker1.Context;
using StudentTracker1.Interfaces;


// This is a controller that has methods to retrieve, add, update and delete student reports.
// I use ASP.NET Core's ApiController attribute and has methods decorated with HTTP verbs,
// such as GET, POST, PUT and DELETE. I use Serilog to log errors and an IStudentReportRepository interface
// to facilitate data retrieval. I also used a List<StudentReport> as a backing store for data.

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
        private readonly IStudentReportRepository _repo;
        public StudentReportController(ILogger<StudentReportController> logger, IStudentReportRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // This is the controller for the StudentReport model, with all the CRUD action methods set up.    
        // The [HttpGet] method handles the GET request, returning all student reports. It uses a repository to retrieve the records,
        // and includes a try/catch block to handle any errors. If there are any errors, the catch block will
        // log the error and return a status code of 500.
        [HttpGet]
        public IEnumerable<StudentReport> Get()
        {
            try
            {
                return _repo.GetAllStudentReports();
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when retrieving student reports");

                // Return a 500 response
                return (IEnumerable<StudentReport>)StatusCode(500);
            }
        }
        // The [HttpGet("{name}")] method handles the GET request with a name parameter, returning the student report with that name.
        // It uses a list of student reports to filter the record, and includes a try/catch block to handle any errors.
        // If there are any errors, the catch block will log the error and return a status code of 500.
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
        // The [HttpPost] method handles the POST request, adding a new student report record. It uses a repository to add
        // the record and includes a try/catch block to handle any errors. If there are any errors, the catch block
        // will log the error.
        [HttpPost]
        public void AddStudentReport([FromBody] StudentReport studentReport)
        {
            try
            {
                _repo.AddStudentReport(studentReport);
            }
            catch (Exception ex)
            {
                //log the error
                Log.Error(ex, "An error occurred when adding student report");
            }
        }
        // The [HttpPut("{name}")] method handles the PUT request with a name parameter, updating the student
        // report record with that name. It uses a list of student reports to filter and update the record
        // and includes a try/catch block to handle any errors. If there are any errors, the catch block
        // will log the error.
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
        // The [HttpDelete("{name}")] method handles the DELETE request with a name parameter, deleting the
        // student report record with that name. It uses a list of student reports to filter and delete the record,
        // and includes a try/catch block to handle any errors. If there are any errors,
        // the catch block will log the error.
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
        // The [HttpGet("StudentsByCourse")] Method handles the GET request with a course parameter, returning all student
        // report records with that course. It uses a list of student reports to filter the records and then returns
        // the list.
        [HttpGet("StudentsByCourse")]
        public IEnumerable<StudentReport> GetStudentReportsByCourse(string course)
        {
            return list.Where(s => string.Equals(s.Course, course, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}