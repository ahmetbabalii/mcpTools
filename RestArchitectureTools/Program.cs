using RestArchitectureTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol;
using ModelContextProtocol.Protocol.Types;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System;

var _minimumLoggingLevel = LoggingLevel.Debug;
HashSet<string> subscriptions = [];

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "RestArchitectureTools.Log"))
    .WriteTo.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Server başlatılıyor...");

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly()
    .WithSetLoggingLevelHandler(async (ctx, ct) =>
     {
         if (ctx.Params?.Level is null)
         {
             throw new McpException("Missing required argument 'level'", McpErrorCode.InvalidParams);
         }

         _minimumLoggingLevel = ctx.Params.Level;

         await ctx.Server.SendNotificationAsync("notifications/message", new
         {
             Level = "debug",
             Logger = "test-server",
             Data = $"Logging level set to {_minimumLoggingLevel}",
         }, cancellationToken: ct);

         return new EmptyResult();
     });

ResourceBuilder resource = ResourceBuilder.CreateDefault().AddService("everything-server");
builder.Services.AddOpenTelemetry()
    .WithTracing(b => b.AddSource("*").AddHttpClientInstrumentation().SetResourceBuilder(resource))
    .WithMetrics(b => b.AddMeter("*").AddHttpClientInstrumentation().SetResourceBuilder(resource))
    .WithLogging(b => b.SetResourceBuilder(resource))
    .UseOtlpExporter();

builder.Services.AddSingleton(subscriptions);
builder.Services.AddHostedService<SubscriptionMessageSender>();
builder.Services.AddHostedService<LoggingUpdateMessageSender>();

builder.Services.AddSingleton<Func<LoggingLevel>>(_ => () => _minimumLoggingLevel);

await builder.Build().RunAsync();

// taskkill /IM RestArchitectureTools.exe /F
// npx @modelcontextprotocol/inspector dotnet run
