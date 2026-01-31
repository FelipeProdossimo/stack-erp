using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using StackErp.Api.Endpoints;
using StackErp.Api.Endpoints.Companies;
using StackErp.Api.Endpoints.Products;
using StackErp.Api.Middleware;
using StackErp.Application;
using StackErp.Application.Companies.Create;
using StackErp.Domain.Companies;
using StackErp.Domain.Products;
using StackErp.Infrastructure.Persistence;
using StackErp.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Stack ERP API",
        Version = "v1",
        Description = "An ERP system built with Clean Architecture and Minimal APIs",
        Contact = new OpenApiContact
        {
            Name = "Felipe Prodossimo",
            Email = "felipe.profissional4@gmail.com"
        }
    });
});*/

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Using connection string: {connectionString}");

builder.Services.AddDbContext<StackErpDbContext>(options =>
{
    options.UseNpgsql(connectionString);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommand).Assembly);
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    /*app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stack ERP API v1");
        c.RoutePrefix = "swagger";
    });*/
}

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StackErpDbContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error applying migrations: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/", () => "Stack ERP API");
app.MapGet("/health", () => "OK");
app.MapDiagnosticEndpoints();
app.MapCompanyEndpoints();
app.MapProductEndpoints();

app.Run();