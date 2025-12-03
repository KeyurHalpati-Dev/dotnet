using Microsoft.EntityFrameworkCore;
using PMS.Repository;
using PMS.Repository.DBContext;   
using PMS.Scope;                  

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<API_DbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Connectionstr")));

// -----------------------------------------------------------
// 2. Register your own services (the extension you already call)
// -----------------------------------------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterService();   // <-- this registers IStoredProcedureRepository, IUserService, etc.

// -----------------------------------------------------------
// 3. Built-in ASP.NET Core services
// -----------------------------------------------------------
builder.Services.AddControllers()
    .AddNewtonsoftJson();
// This line is key
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -----------------------------------------------------------
// 4. (Optional) Store the connection string in a static holder
// -----------------------------------------------------------
// MyConnection.ConnectionString = builder.Configuration.GetConnectionString("Connectionstr");

var app = builder.Build();

// -----------------------------------------------------------
// 5. Middleware pipeline
// -----------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); 
app.UseAuthorization();

app.MapControllers();

app.Run();