using Microsoft.EntityFrameworkCore;

public static class DepartmentRepository{
 public async static Task<List<Department>>GetDepartmentAsync(){
  using(var db = new clockingdbcontext()){
   return await db.Departments.ToListAsync();
  }
 }


 public async static Task<Department>GetDepartmentByIdAsync(int DepartmentId)
 {
  using(var db = new clockingdbcontext()){
   return await db.Departments.FirstOrDefaultAsync(Department => Department.DepartmentId == DepartmentId);
  }
 }

 public async static Task<bool>CreateDepartmentAsync(Department departmentToCreate)
 {
   using (var db = new clockingdbcontext())
  {
   try
   {
    await db.Departments.AddAsync(departmentToCreate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 } 

 public async static Task<bool> UpdateDepartmentAsync(Department departmentToUpdate)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
   db.Departments.Update(departmentToUpdate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }
 }

 public async static Task<bool> DeleteDepartmentAsync(int DepartmentId)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    Department departmentToDelete = await GetDepartmentByIdAsync(DepartmentId);
    db.Remove(departmentToDelete);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 }


}