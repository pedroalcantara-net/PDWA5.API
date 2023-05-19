using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PDWA5.Data.Context;
using PDWA5.Data.Repository;
using PDWA5.Domain.Interface.Repository;
using PDWA5.Domain.Interface.Service;
using PDWA5.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "PDWA5 - Movie Review API",
            Version = "v1"
        }
     );

    var filePath = Path.Combine(System.AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    c.IncludeXmlComments(filePath);
});

#region Database
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ReviewContext>(options => options.UseSqlite(connString));
#endregion

#region Injeção de Dependência
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IReviewService, ReviewService>();
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
