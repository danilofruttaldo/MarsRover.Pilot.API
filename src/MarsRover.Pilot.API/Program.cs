using MarsRover.Pilot.API.Extensions;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCoreLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddWebLayer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.ApplyMigration();
app.UseAuthorization();
app.MapControllers();
app.Run();
