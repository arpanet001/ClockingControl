using Microsoft.EntityFrameworkCore;
public static class TimeRepository{
 public async static Task<List<Time>> GetTimesAsync(){
  using(var db = new clockingdbcontext() ){
   return await db.Times.ToListAsync();
  }
 }
}
 


