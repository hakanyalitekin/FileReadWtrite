using FileReadWtrite.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("PdfDatabase"));
//var app = builder.Build();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRequestLocalization();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("*");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();