using Projects;

var builder = DistributedApplication.CreateBuilder(args);
builder
    .AddProject<GarminTools_Api>("GarminToolsApi")
    .WithUrl("/swagger", "Swagger");

builder.AddJavaScriptApp("GarminTools", "../../../../frontend/garmin-tools/", "start").WithNpm();

builder.Build().Run();