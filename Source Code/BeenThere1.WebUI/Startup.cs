using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeenThere1.Business.Abstract;
using BeenThere1.Business.Concrete;
using BeenThere1.Data.Abstract;
using BeenThere1.Data.Concrete;
using BeenThere1.Entity;
using BeenThere1.WebUI.EmailServices;
using BeenThere1.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BeenThere1.WebUI
{
    public class Startup
    {
        private IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Identity Module configurations
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
                @"Server=localhost;Database=BeenThereDB1;User Id=sa;Password=myPassw0rd;MultipleActiveResultSets=true"));
            services.AddIdentity<BeenThereUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;

                //Lockout

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;


                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                //authorized bir alana giremediginde (giris yapmamis oldugu icin) buraya yonlendir
                options.LoginPath = "/account/login";

                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                //cookie suresi normalde 20 dk. buna true dersen her islemde bu sifirlaniyor. false olursa sifirlanmiyor kesin 20dk var.
                options.SlidingExpiration = true;
                //20 dkyi burda degistirebilirsin
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder()
                {
                    //605. video 13.30 dk. scriptin cookie olusturamamasi icin bunu yaziyoruz. sadece http requestiyle olusturulabilir.
                    HttpOnly = true,
                    Name = ".BeenThere1.Security.Cookie",
                    // cookie calmayi one:
                    SameSite = SameSiteMode.Strict
                };
            });





            services.AddScoped<IExperienceService, ExperienceManager>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ILocationService, LocationManager>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                 new SmtpEmailSender(
                     _Configuration["EmailSender:Host"],
                     _Configuration.GetValue<int>("EmailSender:Port"),
                     _Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                     _Configuration["EmailSender:UserName"],
                     _Configuration["EmailSender:Password"])
                );

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                //SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "categorysummary",
                    pattern: "social/categorysummary/{url}",
                    defaults: new { controller = "social", action = "categorysummary" });
                    

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
