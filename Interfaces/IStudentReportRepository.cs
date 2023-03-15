using StudentTracker1.Context;

namespace StudentTracker1.Interfaces
{
    public interface IStudentReportRepository
    {
        List<StudentReport> GetAllStudentReports();
        void AddStudentReport(StudentReport studentReport);
    }
}
