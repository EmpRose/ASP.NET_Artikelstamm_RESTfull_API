
using Microsoft.EntityFrameworkCore;
using Probearbeit.Context;
using Probearbeit.Context.Kontext;
using Probearbeit.Context.Model;
using Probearbeit.Data;



var builder = WebApplication.CreateBuilder(args);

// Add service DB-Context.                 options go to InMemory database, named "ArticleDB"
builder.Services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase("ArticleDB"));

// Add service "VerboteneWorte"             
builder.Services.AddScoped<VerboteneWorte>();


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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