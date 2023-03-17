using Microsoft.EntityFrameworkCore;
using StudentTracker1.Context;
using StudentTracker1.Interfaces;

// This class implements the IStudentReportRepository to allow for the retrieval and addition
// of student reports from the StudentReportContext.
public class StudentReportsRepository:IStudentReportRepository
{
    // The readonly StudentReportContext allows the _dbContext to be set in the constructor and used
    // throughout the class.
    private readonly StudentReportsContext _dbContext;

    public StudentReportsRepository(StudentReportsContext context)
    {
        _dbContext = context;
    }

    // The GetAllStudentReports method retrieves all student reports and returns them as a List of StudentReport.
    public List<StudentReport> GetAllStudentReports()
    {
        return _dbContext.StudentReports.ToList();
    }

    // The AddStudentReport method adds a StudentReport object to the StudentReportContext and saves the changes.
    public void AddStudentReport(StudentReport studentReport)
    {
        _dbContext.StudentReports.Add(studentReport);
        _dbContext.SaveChanges();
    }
}