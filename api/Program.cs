

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var frontendPath = "./../frontend/www/";
builder.Services.AddSpaStaticFiles(conf => conf.RootPath = frontendPath);
//builder.Services.AddSingleton<DatabaseConnector, DatabaseConnector>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSpaStaticFiles();
/*
app.UseSpaStaticFiles(conf=>
 {
    conf.Options.SourcePath = frontendPath;
});
*/

app.UseAuthorization();

app.MapControllers();

app.Run();
