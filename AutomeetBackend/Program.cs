using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutomeetBackend.Data;
using AutomeetBackend.Repositories;
using AutomeetBackend.Services;

namespace AutomeetBackend
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new DbAdapterConverter());
                });
            builder.Services.AddDbContext<UserDbContext>(options =>
                    options.UseSqlite("Data Source=user.db"));
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UserService>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
