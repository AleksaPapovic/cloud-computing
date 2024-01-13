using BibliotekaEkspozitora.Domain;
using BibliotekaEkspozitura.Http;
using BibliotekaEkspozitura.Repository;
using BibliotekaEkspozitura.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EkspozituraDbContext>(options =>
{
});
builder.Services.AddCentralnaHttpClient(x => x.BaseAddress = new Uri("https://host.docker.internal:44393/"));
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

app.Run();
