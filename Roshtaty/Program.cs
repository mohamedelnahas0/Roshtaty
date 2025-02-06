
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Roshtaty.Core.Entites;
using Roshtaty.Repository.Identity;
using Roshtaty.Core.Repositories;
using Roshtaty.Helpers;
using Roshtaty.Repository;
using Roshtaty.Repository.Data;


namespace Roshtaty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RoshtatyContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            builder.Services.AddDbContext<IdentityContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));

            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            builder.Services.AddSingleton<ISmsService, SmsService>();
            builder.Services.AddSingleton<OTPService>();
            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<IdentityContext>();


            var app = builder.Build(); 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<IdentityUser>();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
