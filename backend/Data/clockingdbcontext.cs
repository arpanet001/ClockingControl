using Microsoft.EntityFrameworkCore;

public class clockingdbcontext:DbContext
{
 public DbSet<Staff> Staffs { get; set; }
 public DbSet<Time> Times {get;set;}
 public DbSet<Department> Departments {get;set;}

 protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=clockingdb;Integrated Security=true");

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  Staff[] staffsToSeed = new Staff[6];
  for (int i = 1; i<=6; i++)
  {
   staffsToSeed[i-1] = new Staff
   {
    StaffId = i,
    PersonalFileNumber = $"The Staff's {i} PersonalFileNumber is ",
    DepartmentId = $"The Staff's {i} DepartmentId is ",
    Department = $"The Staff's {i} Department is ",
    FirstName = $"The Staff's {i} FirstName is ",
    LastName = $"The Staff's {i} LastName is  ",
    Designation = $"The Staff's {i} Role is ",
    Registered = $"Yes/No",
    Active = $"Yes/No",
   };
  }
  modelBuilder.Entity<Staff>().HasData(staffsToSeed);
 }
}


