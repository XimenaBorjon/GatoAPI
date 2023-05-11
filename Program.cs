using GatoAPI.Models;
using GatoAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSignalR();
builder.Services.AddDbContext<Sistem21GatoContext>(optionsBuilder => optionsBuilder.UseMySql
("server=sistemas19.com;database=sistem21_gato;user=sistem21_gatoapi;password=sistemas19_",
Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb")));
var app = builder.Build();

app.UseRouting();

app.MapControllers();
app.MapHub<GatoHub>("/gatohub");
app.Run();
