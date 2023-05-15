var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();
app.Run();