using Microsoft.EntityFrameworkCore;
using StackErp.Api.Endpoints.Companies;
using StackErp.Application.Companies.Create;
using StackErp.Domain.Companies;
using StackErp.Infrastructure.Persistence;
using StackErp.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StackErpDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICreateCompanyUseCase, CreateCompanyHandler>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => "OK");

app.MapCompanyEndpoints();

app.Run();