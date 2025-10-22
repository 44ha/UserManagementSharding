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

builder.Services.AddDbContext<AppDbContext1>(opt => opt.UseSqlite("Data Source=db1.db"));
builder.Services.AddDbContext<AppDbContext2>(opt => opt.UseSqlite("Data Source=db2.db"));

builder.Services.AddScoped<ShardManager>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
