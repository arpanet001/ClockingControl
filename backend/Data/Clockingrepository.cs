using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;

public class Clockingrepository{

 public async static Task<List<Clocking>> GetClockingsAsync(){
  using(var db = new clockingdbcontext() ){
   return await db.Clockings.ToListAsync();
  }
 }

 public async static Task<Clocking>GetClockingByPersonalFileNumberAsync(string PersonalFileNumber)
 {
  using(var db = new clockingdbcontext()){
   return await db.Clockings.FirstOrDefaultAsync(Clocking => Clocking.PersonalFileNumber == PersonalFileNumber);
  }
 }

 public async static Task<bool> CreatePersonalFileNumberAsync(Clocking clockingToCreate)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    await db.Clockings.AddAsync(clockingToCreate);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }
 }

  public async static Task<string> UpdateClockingAsync(string personalFileNumber)
    {
        try
        {
            //var staff = new StaffsRepository();
            var user = await StaffsRepository.GetStaffByPersonalFileNumberAsync(personalFileNumber);
            if (user == null)
                return ("User Not Registered");

            var time = new Time ();
            time.PersonalFileNumber = personalFileNumber;
            time.FirstName = user.FirstName;
            time.LastName = user.LastName;

            //var timerepository = new TimeRepository();
            await TimeRepository.UpdateTimeAsync(time);

        }
        catch (Exception)
        {
            return ("Error updating data");
        }
        return("Response to device clocked");
    }
    
  public async static Task<bool> DeleteClockingAsync(string PersonalFileNumber)
 {
  using (var db = new clockingdbcontext())
  {
   try
   {
    Clocking personalfilenumberToDelete = await GetClockingByPersonalFileNumberAsync(PersonalFileNumber);
    db.Remove(personalfilenumberToDelete);
    return await db.SaveChangesAsync() >= 1 ;
    
   }
   catch (System.Exception)
   {
    return false;
   }
   
  }

 }
}