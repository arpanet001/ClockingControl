using Microsoft.EntityFrameworkCore;

public static class StaffsRepository{
 public async static Task<List<Staff>> GetStaffsAsync(){
  using(var db = new clockingdbcontext() ){
   return await db.Staffs.ToListAsync();
  }
 }

 public async static Task<Staff> GetStaffByPersonalFileNumberAsync(string PersonalFileNumber ){
  using (var db = new clockingdbcontext()){
   return await db.Staffs.FirstOrDefaultAsync(Staff => Staff.PersonalFileNumber == PersonalFileNumber);
  }
 }  

 public async static Task<bool> CreateStaffAsync(Staff staffToCreate)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    await db.Staffs.AddAsync(staffToCreate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }
 }
 public async static Task<bool> UpdateStaffAsync(Staff StaffToUpdate)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
   db.Staffs.Update(StaffToUpdate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }
 }
 public async static Task<bool> DeleteStaffAsync(string PersonalFileNumber)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    Staff StaffToDelete = await GetStaffByPersonalFileNumberAsync(PersonalFileNumber);
    db.Remove(StaffToDelete);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 }

}