using Microsoft.EntityFrameworkCore;
public static class TimeRepository{
 public async static Task<List<Time>> GetTimeDetailsAsync(){
  using(var db = new clockingdbcontext() ){
   return await db.TimeDetails.ToListAsync();
  }
 }

 public async static Task<bool> CreateTimeAsync(Time timeToCreate)
 {
   using (var db = new clockingdbcontext())
  {
   try
   {
    await db.TimeDetails.AddAsync(timeToCreate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 } 

 public async static Task<Time>GetTimeByPersonalFileNumberAsync(string PersonalFileNumber)
 {
  using(var db = new clockingdbcontext()){
   return await db.TimeDetails.FirstOrDefaultAsync(Time => Time.PersonalFileNumber == PersonalFileNumber);
  }
 }

  public async static Task<bool> UpdateTimeAsync(Time timeToUpdate)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
   db.TimeDetails.AddAsync(timeToUpdate);
    await db.SaveChangesAsync();
    return true;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }
 }

 public async static Task<bool> DeleteTimeAsync(string PersonalFileNumber)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    Time timeToDelete = await GetTimeByPersonalFileNumberAsync(PersonalFileNumber);
    db.Remove(timeToDelete);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 }

}
 


