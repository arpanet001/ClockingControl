using clockingapi.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy",builder=>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");

    });

});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptions => {
    SwaggerGenOptions.SwaggerDoc("v1",new OpenApiInfo {Title="CLOCKING CONTROL",Version="v1"});
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions => 
{
    swaggerUIOptions.DocumentTitle = "CLOCKING CONTROL";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","CLOCKING CONTROL WEB API");
    swaggerUIOptions.RoutePrefix = string.Empty;
}
);


app.UseHttpsRedirection();

app.UseCors("CORSPolicy");


app.UseAuthorization();
app.MapControllers();

app.MapGet("/get-all-staffs",async () => await StaffsRepository.GetStaffsAsync())
.WithTags("STAFFS ENDPOINTS");
;


app.MapGet("/get-staff-by-personalfilenumber/{PersonalFileNumber}",async(string PersonalFileNumber)=>{
    Staff StaffToReturn = await StaffsRepository.GetStaffByPersonalFileNumberAsync(PersonalFileNumber);
    if(StaffToReturn!=null){
        return Results.Ok(StaffToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("STAFFS ENDPOINTS");


app.MapPost("/create-staff",async(Staff StaffToCreate)=>{
    bool createSuccessful = await StaffsRepository.CreateStaffAsync(StaffToCreate);
    if(createSuccessful){
        return Results.Ok(StaffToCreate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("STAFFS ENDPOINTS");

app.MapPut("/update-staff",async(Staff StaffToUpdate)=>{
    bool updateSuccessful = await StaffsRepository.UpdateStaffAsync(StaffToUpdate);
    if(updateSuccessful){
        return Results.Ok(StaffToUpdate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("STAFFS ENDPOINTS");

app.MapDelete("/delete-staff-by-personalfilenumber/{PersonalFileNumber}",async(string PersonalFileNumber)=>{
    bool deleteSuccessful = await StaffsRepository.DeleteStaffAsync(PersonalFileNumber);
    if(deleteSuccessful){
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("STAFFS ENDPOINTS");

app.MapGet("/get-all-staffs-clocking-and-clockout-time",async () => await TimeRepository.GetTimeDetailsAsync()).
WithTags("TIME ENDPOINTS");

app.MapGet("/get-staffs-clocking-and-clockout-time-by-id/{StaffId}",async(string PersonalFileNumber)=>{
    Time TimeToReturn = await TimeRepository.GetTimeByPersonalFileNumberAsync(PersonalFileNumber);
    if(TimeToReturn!=null){
        return Results.Ok(TimeToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("TIME ENDPOINTS");

app.MapPost("/create-time-details",async(Time timeToCreate)=>{
    bool createSuccessful = await TimeRepository.CreateTimeAsync(timeToCreate);
    if(createSuccessful){
        return Results.Ok(timeToCreate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("TIME ENDPOINTS");

app.MapPut("/update-time-details",async(Time TimeToUpdate)=>{
    bool updateSuccessful = await TimeRepository.UpdateTimeAsync(TimeToUpdate);
    if(updateSuccessful){
        return Results.Ok(TimeToUpdate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("TIME ENDPOINTS");

app.MapDelete("/delete-time-details-by-id/{StaffId}",async(string PersonalFileNumber)=>{
    bool deleteSuccessful = await TimeRepository.DeleteTimeAsync(PersonalFileNumber);
    if(deleteSuccessful){
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("TIME ENDPOINTS");

app.MapGet("/get-all-departments",async () => await DepartmentRepository.GetDepartmentAsync()).WithTags("DEPARTMENT ENDPOINTS");

app.MapGet("/get-department-by-id/{DepartmentId}",async(int DepartmentId)=>{
    Department DepartmentToReturn = await DepartmentRepository.GetDepartmentByIdAsync(DepartmentId);
    if(DepartmentToReturn!=null){
        return Results.Ok(DepartmentToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("DEPARTMENT ENDPOINTS");

app.MapPost("/create-department",async(Department departmentToCreate)=>{
    bool createSuccessful = await DepartmentRepository.CreateDepartmentAsync(departmentToCreate);
    if(createSuccessful){
        return Results.Ok(departmentToCreate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("DEPARTMENT ENDPOINTS");

app.MapPut("/update-department",async(Department departmentToUpdate)=>{
    bool updateSuccessful = await DepartmentRepository.UpdateDepartmentAsync(departmentToUpdate);
    if(updateSuccessful){
        return Results.Ok(departmentToUpdate);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("DEPARTMENT ENDPOINTS");

app.MapDelete("/delete-department-by-id/{DepartmentId}",async(int DepartmentId)=>{
    bool deleteSuccessful = await DepartmentRepository.DeleteDepartmentAsync(DepartmentId);
    if(deleteSuccessful){
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("DEPARTMENT ENDPOINTS");

app.MapPost("/create-clocking",async(Clocking clockingToCreate)=>{
    bool createSuccessful = await Clockingrepository.CreatePersonalFileNumberAsync(clockingToCreate);
    if(createSuccessful){
        return Results.Ok("Response to device clocked");
    }
    else{
        return Results.BadRequest("User Not Registered");
    }
}).WithTags("CLOCKING ENDPOINTS");

app.MapGet("/get-all-cllockings",async () => await Clockingrepository.GetClockingsAsync())
.WithTags("CLOCKING ENDPOINTS");

app.MapGet("/get-clocking-by-personalfilenumber/{PersonalFileNumber}",async(string PersonalFileNumber)=>{
    Clocking ClockingToReturn = await Clockingrepository.GetClockingByPersonalFileNumberAsync(PersonalFileNumber);
    if(ClockingToReturn!=null){
        return Results.Ok(ClockingToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("CLOCKING ENDPOINTS");

app.MapPost("/update-clocking",async(string personalFileNumber)=>{
    string updateSuccessful = await Clockingrepository.UpdateClockingAsync(personalFileNumber);
    if(updateSuccessful == "Response to device clocked"){
        return Results.Ok(updateSuccessful + " " + personalFileNumber);
    }
    else{
        return Results.BadRequest(updateSuccessful);
    }
}).WithTags("CLOCKING ENDPOINTS");

app.MapDelete("/delete-personalfilenumber",async(string PersonalFileNumber)=>{
    bool deleteSuccessful = await Clockingrepository.DeleteClockingAsync(PersonalFileNumber);
    if(deleteSuccessful){
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("CLOCKING ENDPOINTS");


app.Run();
