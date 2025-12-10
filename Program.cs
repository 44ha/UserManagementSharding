using Microsoft.EntityFrameworkCore;
using UserManagementSharding.Data;
using UserManagementSharding.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext1>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Shard1")));
builder.Services.AddDbContext<AppDbContext2>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Shard2")));

builder.Services.AddScoped<ShardManager>();
builder.Services.AddScoped<UserService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); 
});

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToFile("index.html");
using (var scope = app.Services.CreateScope())
{
    var db1 = scope.ServiceProvider.GetRequiredService<AppDbContext1>();
    db1.Database.Migrate();

    var db2 = scope.ServiceProvider.GetRequiredService<AppDbContext2>();
    db2.Database.Migrate();
}
app.Run();
