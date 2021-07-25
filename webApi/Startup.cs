using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webApi.Contracts;
using webApi.Contracts.Articles;
using webApi.Contracts.Articles.Publisher;
using webApi.Contracts.Articles.Tags;
using webApi.CustomBinders;
using webApi.Models.SiteSettings;
using webApi.Services;
using webApi.Services.Articles;
using webApi.Services.Articles.Publisher;
using webApi.Services.Articles.Tags;
using Microsoft.Extensions.FileProviders;
using System.IO;

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

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticlePublisherService, ArticlePublisherService>();
            services.AddScoped<ITagService, TagService>();

            services.AddMediatR(typeof(Startup));

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
