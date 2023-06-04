using FitnessAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy(name: "UI", policy => {
        // PORTS:
        // 4200 - ANGULAR CLIENT
        // 3000 - REACT CLIENT
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(
            "http://localhost:4200", "http://localhost:3000"
        );
    });
});


// Only for debuging purposes on local machine; 
const string ConnectionString = 
    "server=localhost;port=3306;database=fitnessapp;uid=root;password=FitnessApp123";


builder.Services.AddDbContext<FitnessAppDbContext>(options => options.UseMySQL(
    ConnectionString
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("UI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
