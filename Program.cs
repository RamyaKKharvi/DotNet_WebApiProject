using Microsoft.EntityFrameworkCore;
using WebAPITest.Model;
using WebAPITest.Repository;
using WebAPITest.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

var teacherConnectionString = builder.Configuration.GetConnectionString("TeacherCS");

builder.Services.AddDbContext<TeacherDBContext>(
    options => options.UseMySql(teacherConnectionString, ServerVersion.AutoDetect(teacherConnectionString)));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Note: Add Student Service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
