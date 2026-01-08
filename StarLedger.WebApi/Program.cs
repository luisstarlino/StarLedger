using Scalar.AspNetCore;
using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases;
using StarLedger.Infrastructure.Pesistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddScoped<AddEntryUseCase>();
builder.Services.AddScoped<ILedgerRepository, InMemoryRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
