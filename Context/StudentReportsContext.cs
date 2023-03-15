using Microsoft.EntityFrameworkCore;
using StudentTracker1.Context;

public class StudentReportsContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public StudentReportsContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetSection("ConnectionString").Value);
    }

    public DbSet<StudentReport> StudentReports { get; set; }
}