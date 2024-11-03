using Microsoft.EntityFrameworkCore;
using MySchool.Api.Data;
using MySchool.Api.Host.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Services
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
using(var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
    context.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
