using BibliotekaCentralna.Domain;
using BibliotekaCentralna.Middleware;
using BibliotekaCentralna.Repository;
using BibliotekaCentralna.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});
string connection = Environment.GetEnvironmentVariable("CONNECTION");
builder.Services.AddDbContext<CentralnaDbContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString(connection)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CentralnaDbContext>();
    context.Database.Migrate();
}

app.Run();
