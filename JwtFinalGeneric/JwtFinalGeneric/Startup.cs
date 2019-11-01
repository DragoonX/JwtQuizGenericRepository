using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtFinalGeneric.Interfaces;
using JwtFinalGeneric.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JwtFinalGeneric
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<XContext>(opt => opt.UseSqlServer("Server=localhost;Database=JwtGeneric;User Id=sa;Password=123;"));
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options =>
                    options.WithOrigins("http://localhost:5001")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
            app.UseMvc();
        }
    }
}
