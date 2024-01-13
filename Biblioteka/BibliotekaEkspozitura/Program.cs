using BibliotekaEkspozitora.Domain;
using BibliotekaEkspozitura.Http;
using BibliotekaEkspozitura.Repository;
using BibliotekaEkspozitura.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});
string connection = Environment.GetEnvironmentVariable("CONNECTION");
builder.Services.AddDbContext<EkspozituraDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString(connection)));
builder.Services.AddCentralnaHttpClient(x => x.BaseAddress = new Uri("https://localhost:44393/"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EkspozituraDbContext>();
    context.Database.Migrate();
}

app.Run();
