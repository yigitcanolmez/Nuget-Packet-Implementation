using Microsoft.EntityFrameworkCore;
using SOD.Api.Middlewares;
using SOD.Business;
using SOD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SampleProjectDbContext>(options =>
options.UseMySQL(
builder.Configuration.GetConnectionString("MySQL")!)
);
builder.Services.AddMvc();
builder.Services.AddContainerServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseRouting();

app.UseCustomAuthMiddleware();

app.MapControllers();

app.Run();
