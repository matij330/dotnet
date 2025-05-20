using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnet.Models;
namespace dotnet.Data;

public class ApplicationDbContext : IdentityDbContext
{
    DbSet<Student>Students{get; set;}
    DbSet<StudentOceny>Grades{get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
