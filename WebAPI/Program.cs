using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DonationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);

builder.Services.AddCors();


var app = builder.Build();

app.UseCors(options =>
            options.WithOrigins("http://localhost:3002")
            .AllowAnyHeader()
            .AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.UseCors(options =>
    //         options.WithOrigins("http://localhost:3002")
    //         .AllowAnyHeader()
    //         .AllowAnyMethod());
}

// app.UseCors(options =>
//             options.WithOrigins("http://localhost:3002")
//             .AllowAnyHeader()
//             .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
