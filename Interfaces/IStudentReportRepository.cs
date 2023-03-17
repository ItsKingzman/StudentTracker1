using StudentTracker1.Context;

namespace StudentTracker1.Interfaces
{
    public interface IStudentReportRepository
    {
        List<StudentReport> GetAllStudentReports();
        void AddStudentReport(StudentReport studentReport);
    }
}
//This interface provides an outline and skeleton of what potential repositories of
//StudentReport would need to contain and be able to do. 
//It requires the repository to be able to get all student reports,
//as well as to add student reports.