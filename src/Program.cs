using Carta.Models;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Origins",
        policy  =>
        {
            policy.WithOrigins("*");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

var dbSettings = builder.Configuration.GetSection("DbSettings").Get<DbSettings>();

var app = builder.Build();

await DB.InitAsync(dbSettings!.Database, dbSettings.Host, dbSettings.Port);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Origins");

app.UseAuthorization();

app.MapControllers();

app.Run();
