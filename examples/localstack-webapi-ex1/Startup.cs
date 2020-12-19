using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.CloudWatchLogs;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.AwsCloudWatch;
using System.IO;

namespace localstack_webapi_ex1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings.AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            if (Environment.IsDevelopment())
            {
                services.AddSingleton<IAmazonS3>(provider => {
                    var settings = provider.GetService<AppSettings.AppSettings>();
                    return new AmazonS3Client(new AmazonS3Config {
                        UseHttp = true,
                        ServiceURL = settings.Aws.S3.ServiceUrl,
                        ForcePathStyle = true
                    });
                });
                services.AddSingleton<IAmazonCloudWatchLogs>(provider => {
                    var settings = provider.GetService<AppSettings.AppSettings>();
                    return new AmazonCloudWatchLogsClient(new AmazonCloudWatchLogsConfig {
                        UseHttp = true,
                        ServiceURL = settings.Aws.CloudWatch.ServiceUrl
                    });
                });
            } 
            else
            {
                services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
                services.AddAWSService<IAmazonS3>();
                services.AddAWSService<IAmazonCloudWatchLogs>();  
            }

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IAmazonCloudWatchLogs cloudWatchLogs,
            AppSettings.AppSettings settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs.txt")
                .WriteTo.AmazonCloudWatch(new CloudWatchSinkOptions {
                    CreateLogGroup = true,
                    LogGroupName = settings.Aws.CloudWatch.GroupName,
                    TextFormatter = new AmazonCloudWatchTextFormatter(),
                    LogStreamNameProvider = new AmazonCloudWatchLogStreamNameProvider()
                }, cloudWatchLogs)
                .CreateLogger();

            app.UseCors(builder => builder.WithOrigins(settings.ClientUrl)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public class AmazonCloudWatchLogStreamNameProvider : ILogStreamNameProvider {
        public string GetLogStreamName() {
            var now = DateTime.UtcNow;
            return $"{now.Year}-{now.Month}-{now.Day+6}";
        }
    }

    public class AmazonCloudWatchTextFormatter : ITextFormatter {
        public void Format(LogEvent logEvent, TextWriter output) {
            logEvent.RenderMessage(output);
        }
    }
}
