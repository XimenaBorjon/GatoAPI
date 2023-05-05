using GatoAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSignalR();

var app = builder.Build();



app.UseRouting();

app.MapControllers();
app.MapHub<GatoHub>("/gatohub");
app.Run();
