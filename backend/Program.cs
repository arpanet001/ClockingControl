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


app.MapGet("/get-staff-by-id/{StaffId}",async(int StaffId)=>{
    Staff StaffToReturn = await StaffsRepository.GetStaffByIdAsync(StaffId);
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

app.MapDelete("/delete-staff-by-id/{StaffId}",async(int StaffId)=>{
    bool deleteSuccessful = await StaffsRepository.DeleteStaffAsync(StaffId);
    if(deleteSuccessful){
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("STAFFS ENDPOINTS");

app.MapGet("/get-all-staffs-clocking-and-clockout-time",async () => await TimeRepository.GetTimesAsync()).
WithTags("TIME ENDPOINTS");
;

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

app.Run();
