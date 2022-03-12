using AutoFilterer.Swagger;
using EasyProfiler.PostgreSQL.Extensions;
using EasyProfiler.Web.Dotnet6;
using MarkdownDocumenting.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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

builder.Services.AddDocumentation();

builder.Services.AddDbContext<SampleDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddEasyProfiler(builder.Services);
});

builder.Services.AddEasyProfilerDbContext(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
}, configuration =>
{
    configuration.Resulation = EasyProfiler.CronJob.Common.Resulation.HIGH;
});

var app = builder.Build();

app.MigrateEasyProfiler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.EnableDeepLinking();
    options.ShowExtensions();
    options.DisplayRequestDuration();
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    options.RoutePrefix = "api-docs";
    options.SwaggerEndpoint("/swagger/EasyProfiler/swagger.json", "EasyProfilerSwagger");
});

app.UseDocumentation(opts => builder.Configuration.Bind("DocumentationOptions", opts));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
