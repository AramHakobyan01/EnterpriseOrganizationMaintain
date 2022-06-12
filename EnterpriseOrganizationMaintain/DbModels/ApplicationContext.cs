using EnterpriseOrganizationMaintain.Models;
using Microsoft.EntityFrameworkCore;
using static EnterpriseOrganizationMaintain.Models.Employee;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<HrData> HrData => Set<HrData>();
    public ApplicationContext() => Database.EnsureCreated();


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = OfficeDb; Trusted_Connection = True;");
    }
}
