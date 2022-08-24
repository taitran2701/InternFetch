using InternBA.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using InternBA.Infrastructure.Data;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Use extension method 
builder.Services.AddMyDbContext(config);

//MediatR 
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//Fluent Validation
builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

//JWT


builder.Services.AddDbContext<InternBADBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydata"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//logging


app.Run();
