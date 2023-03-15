using Microsoft.EntityFrameworkCore;
using StudentTracker1.Context;
using StudentTracker1.Interfaces;

public class StudentReportsRepository:IStudentReportRepository
{
    private readonly StudentReportsContext _dbContext;

    public StudentReportsRepository(StudentReportsContext context)
    {
        _dbContext = context;
    }

    // method to retrieve all student reports
    public List<StudentReport> GetAllStudentReports()
    {
        return _dbContext.StudentReports.ToList();
    }

    // method to add new student report
    public void AddStudentReport(StudentReport studentReport)
    {
        _dbContext.StudentReports.Add(studentReport);
        _dbContext.SaveChanges();
    }
}