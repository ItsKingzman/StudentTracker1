using StudentTracker1.Context;

public class StudentReportsRepository
{
    private readonly StudentReportsContext _dbContext;

    public StudentReportsRepository()
    {
        _dbContext = new StudentReportsContext();
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
