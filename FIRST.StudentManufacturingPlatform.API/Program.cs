using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Application.ACL;
using FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.CommandServices;
using FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.QueryServices;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Assets.Infrastructure.Persistence.EFC.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.ACL;
using FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Repositories;
using FIRST.StudentManufacturingPlatform.API.Operations.Application.Internal.CommandServices;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "FIRST.StudentManufacturingPlatform.API",
            Version = "v1",
            Description = "FIRST Student Manufacturing Platform API",
            TermsOfService = new Uri("https://firststudentinc.com/"),
            Contact = new OpenApiContact
            {
                Name = "Alison Arrieta",
                Email = "alisonarrieta06@gmail.com"
                
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
            
        });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IBusCommandService, BusCommandService>();
builder.Services.AddScoped<IBusQueryService, BusQueryService>();
builder.Services.AddScoped<IBusesContextFacade, BusesContextFacade>();

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentCommandService, AssignmentCommandService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();