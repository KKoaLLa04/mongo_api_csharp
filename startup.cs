using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MongoDbDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Cấu hình MongoDB
            services.AddSingleton<IMongoClient, MongoClient>(s =>
                new MongoClient(Configuration.GetConnectionString("MongoDb")));

            services.AddScoped<IMongoDatabase>(s =>
                s.GetRequiredService<IMongoClient>().GetDatabase("config")); // Thay your_database_name bằng tên cơ sở dữ liệu

            services.AddScoped<VersionControlService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Cấu hình middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
