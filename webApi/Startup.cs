using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using webApi.Models.SiteSettings;
using webApi.ServiceInterfaces.Tags;
using webApi.Services.Tags;
using webApi.Services.Articles.Tags;

namespace webapi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IConfiguration SiteSettingsConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddMvc(options =>
            {
                // add custom binder to beginning of collection
                // options.ModelBinderProviders.Insert(0, new CustomBinderProvider());                
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            services.AddMediatR(typeof(Startup));

            services.AddScoped<ITagParentService, TagParentService>();
            services.AddScoped<ITagChildrenService, TagChildrenService>();
            services.AddScoped<ITagPathService, TagPathService>();

            var siteSettingsConfig = Configuration.GetSection("SiteSettings");//.Get<SiteSettingsModel>();
            services.Configure<SiteSettingsModel>(siteSettingsConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "wwwroot/uploads")),
                RequestPath = "/wwwroot/uploads"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
