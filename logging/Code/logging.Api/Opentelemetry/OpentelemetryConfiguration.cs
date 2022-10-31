using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using OpenTelemetry.Resources;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
namespace logging.Api.Opentelemetry
{
    public class OpentelemetryConfiguration
    {

       public static ResourceBuilder GetResourceBuilder(IWebHostEnvironment webHostEnvironment)
        {
            var version = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyFileVersionAttribute>()!
                .Version;
            var attributes = new List<KeyValuePair<string, object>>();// adding elements
            attributes.Add(new KeyValuePair<string, object>("deployment.environment", webHostEnvironment.EnvironmentName));
            attributes.Add(new KeyValuePair<string, object>("host.name", Environment.MachineName));
            return ResourceBuilder
         .CreateDefault()
         .AddService(webHostEnvironment.ApplicationName, serviceVersion: version)
         .AddAttributes(attributes)
         .AddEnvironmentVariableDetector();
        }

       public static void Enrich(Activity activity, string eventName, object obj)
        {
            if (obj is HttpRequest request)
            {
                var context = request.HttpContext;
                activity.AddTag("http.protocol", request.Protocol);
                activity.AddTag("http.scheme", request.Scheme);
                activity.AddTag("http.client_ip", context.Connection.RemoteIpAddress);
            }
        }
    }
}