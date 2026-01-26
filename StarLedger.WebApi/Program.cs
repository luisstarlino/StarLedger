using Microsoft.Extensions.Caching.Memory;
using Scalar.AspNetCore;
using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases;
using StarLedger.Application.UseCases.Handler;
using StarLedger.Infrastructure.Pesistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddMemoryCache();
builder.Services.AddScoped<AddEntryUseCase>();
builder.Services.AddSingleton<ILedgerRepository, InMemoryRepository>();
builder.Services.AddSingleton<ILedgerReadRepository, InMemoryReadRepository>();
builder.Services.AddSingleton<ILedgerCacheInvalidator, LedgerCacheInvalidator>();
builder.Services.AddSingleton<ILedgerReadRepository>(sp =>
{
    var baseRepo = new InMemoryReadRepository(sp.GetRequiredService<ILedgerRepository>());
    return new InCachedLedgerRepository(baseRepo, sp.GetRequiredService<IMemoryCache>(), sp.GetRequiredService<ILedgerCacheInvalidator>());
});

builder.Services.AddScoped<AddEntryCommandHandler>();
builder.Services.AddScoped<GetBalanceQueryHandler>();
builder.Services.AddScoped<GetHistoryEntriesHandler>();

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
