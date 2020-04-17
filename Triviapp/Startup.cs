using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Triviapp.Data;

namespace Triviapp
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
            //AUTHENTICATION
            services.AddAuthentication("CookieAuth") //COOKIE FOR USERS
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.Name = "User.Cookie";
                });
            //RAZOR PAGES
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Quizzes/Create"); //ONLY USERS CAN ACCESS THESE PAGES
                    options.Conventions.AuthorizePage("/Account/Profile");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });
            //SESSIONS
            services.AddSession();
            //DATABASE
            services.AddDbContext<TriviappContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("TriviappContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //HTTP
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //ROUTING
            app.UseRouting();
            //AUTHENTICATION
            app.UseAuthentication();
            //AUTHORIZATION
            app.UseAuthorization();
            //SESSIONS
            app.UseSession();
            //ENDPOINTS
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
