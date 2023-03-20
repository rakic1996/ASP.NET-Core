using Microsoft.EntityFrameworkCore;
using Projekat.Core.Domain;
using Projekat.Core.Services;
using Projekat.Core.Services.Abstraction;
using Projekat.Infrastructure;
using Projekat.Infrastructure.Presentation;
using Projekat.Repositories;
using Projekat.Core.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase"))); //connection string 
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient(typeof(ICountryService), typeof(CountryService));
builder.Services.AddTransient(typeof(IRepository<Employee>), typeof(EmployeeRepository<Employee>));
builder.Services.AddTransient(typeof(IRepository<Client>), typeof(ClientRepository<Client>));
builder.Services.AddTransient(typeof(ICountryRepository), typeof(CountryRepository));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(MyAllowSpecificOrigins);

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
