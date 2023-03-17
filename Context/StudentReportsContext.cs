using Microsoft.EntityFrameworkCore;
using StudentTracker1.Context;

public class StudentReportsContext : DbContext
{
    protected readonly IConfiguration Configuration;

    //The constructor takes IConfiguration as a parameter and sets the Configuration field.
    public StudentReportsContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    // The OnConfiguring method uses this Configuration field to acquire the app settings connection string
    // and uses that to configure the connection to the SQL Server database. 
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetSection("ConnectionString").Value);
    }
    // The StudentReports property allows the application to access the StudentReport table in the database.
    public DbSet<StudentReport> StudentReports { get; set; }
}