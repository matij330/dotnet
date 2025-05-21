using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnet.Models;
namespace dotnet.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Student> Student {get;set;}
    public DbSet<StudentGrades> StudentGrades {get;set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
