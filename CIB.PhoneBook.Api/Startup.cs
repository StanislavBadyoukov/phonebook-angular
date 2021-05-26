using CIB.PhoneBook.Application;
using CIB.PhoneBook.Domain;
using CIB.PhoneBook.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CIB.PhoneBook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddDbContext<PhoneBookDbContext>(options =>
            {
                MigrateDb();
                options.UseSqlServer(Configuration.GetConnectionString("PhoneBookApiApiDefaultConnection"));
            });

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IPhoneBookService, PhoneBookService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseCors("CorsApi");

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDb()
        {
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext(new string[0]);
            
            dbContext.Database.Migrate();
        }
    }
}
