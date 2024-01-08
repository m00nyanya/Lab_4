using System.ComponentModel;
using Laba4.Controllers;
using Microsoft.EntityFrameworkCore;
using Laba4.Data;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("ContactDb"));
        

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
        
        app.MapControllers();

        app.Run();
    }
}