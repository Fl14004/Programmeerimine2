using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application;
using Projektijuhtimine.Application.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Õppeprojekti jaoks loob andmebaasi esmakäivitamisel ja lisab näidisandmed.
// Kui kasutate migratsioone, asendage EnsureCreatedAsync() käsuga MigrateAsync()
// pärast InitialCreate migratsiooni loomist. Ärge kasutage EnsureCreated ja Migrate koos.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.EnsureCreatedAsync();
    await SeedData.InitializeAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/api/users", async (ApplicationDbContext db) => await db.Users.AsNoTracking().ToListAsync());
app.MapGet("/api/projects", async (ApplicationDbContext db) => await db.Projects.AsNoTracking().ToListAsync());
app.MapGet("/api/projects/{id:int}", async (int id, ApplicationDbContext db) =>
    await db.Projects.AsNoTracking().Where(p => p.Id == id).Select(p => new { p.Id, p.Name, p.StartDate, p.Deadline, p.Budget, p.HourlyRate,
        CurrentCost = p.Tasks.Sum(t => t.FixedPrice ?? t.WorkLogs.Sum(w => w.Hours) * p.HourlyRate) }).FirstOrDefaultAsync() is { } project
        ? Results.Ok(project) : Results.NotFound());
app.MapGet("/api/tasks", async (ApplicationDbContext db) => await db.Tasks.AsNoTracking().Include(t => t.Project).Include(t => t.ResponsibleUser).ToListAsync());
app.MapGet("/api/worklogs", async (ApplicationDbContext db) => await db.WorkLogs.AsNoTracking().ToListAsync());
app.MapGet("/api/attachments", async (ApplicationDbContext db) => await db.Attachments.AsNoTracking().ToListAsync());
app.MapGet("/", () => Results.Ok(new { message = "Projektijuhtimise API töötab", swagger = "/swagger" }));

app.Run();
