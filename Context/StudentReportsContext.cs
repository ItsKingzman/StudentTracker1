using Microsoft.EntityFrameworkCore;
using StudentTracker1.Context;

public class StudentReportsContext : DbContext
{
    public StudentReportsContext() : base() { }
    public DbSet<StudentReport> StudentReports { get; set; }
}