using logging.Api.Installer;
using logging.Api.Middleware;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using logging.Api.Opentelemetry;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Exporter.OpenTelemetryProtocol;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace logging.Api
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
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
			services.AddOpenTelemetryTracing(
                    builder =>
                    {
                        builder
                            .SetResourceBuilder(OpentelemetryConfiguration.GetResourceBuilder(WebHostEnvironment))
                            .AddAspNetCoreInstrumentation(
                                options =>
                                {
                                    options.Enrich = OpentelemetryConfiguration.Enrich;
                                    options.RecordException = true;
                                })
                            .AddHttpClientInstrumentation()
                            .AddOtlpExporter(otlpOptions =>
                                {
                                    otlpOptions.Endpoint = new Uri(Configuration["OpenTelemetry:OtlpExporterEndpoint"]);
                                    otlpOptions.Protocol = OtlpExportProtocol.Grpc;
                                });
                        if (WebHostEnvironment.IsDevelopment())
                        {
                            builder.AddConsoleExporter(
                                options => options.Targets = ConsoleExporterOutputTargets.Console);
                        }
                    });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAutoMapper(typeof(Startup));

            APIInstaller apiInstaller = new APIInstaller(services, Configuration);
            apiInstaller.Install();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(
                c => c.SerializeAsV2 = true
            );
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "logging V1");
            });

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseElmah();

            app.UseRequestLoggingMiddleWare();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
