using Microsoft.EntityFrameworkCore;
using SecondExam.Repository;
using SecondExam.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=SecondExam;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseAuthorization();

app.MapControllers();

app.Run();
