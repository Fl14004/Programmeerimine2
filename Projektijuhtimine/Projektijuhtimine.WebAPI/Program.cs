using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDbContext).Assembly));
var app = builder.Build();
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => Results.Ok(new { message = "Projektijuhtimise API töötab", swagger = "/swagger" }));
app.Run();
