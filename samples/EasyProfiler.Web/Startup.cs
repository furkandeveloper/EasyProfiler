using AutoFilterer.Swagger;
using EasyProfiler.AspNetCore;
using EasyProfiler.PostgreSQL.Extensions;
using MarkdownDocumenting.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace EasyProfiler.Web
{
    /// <summary>
    /// Startup of App
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration Object
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Ctor of Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            
            services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                .AddEasyProfiler(services);
            });

            services.AddEasyProfilerDbContext(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }, options=>
            {
                options.Resulation = CronJob.Common.Resulation.HIGH;
                //options.UseCronExpression = true;
                //options.CronExpression = "* 1 * * *";
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("EasyProfiler", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Easy Profiler",
                    Version = "1.0.0",
                    Description = "This repo, provides query profiler for EF Core.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "furkan.dvlp@gmail.com",
                        Url = new Uri("https://github.com/furkandeveloper/EasyProfiler")
                    }
                });
                options.UseAutoFiltererParameters();
                var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

                if (File.Exists((filePath)))
                {
                    options.IncludeXmlComments(filePath);
                }
                options.DescribeAllParametersInCamelCase();
            });

            services.AddDocumentation();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyEasyProfilerPostgreSQL();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(options=>
            {
                options.EnableDeepLinking();
                options.ShowExtensions();
                options.DisplayRequestDuration();
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.RoutePrefix = "api-docs";
                options.SwaggerEndpoint("/swagger/EasyProfiler/swagger.json","EasyProfilerSwagger");
            });
            app.UseDocumentation(opts => this.Configuration.Bind("DocumentationOptions", opts));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
