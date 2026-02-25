using Projects;

var builder = DistributedApplication.CreateBuilder(args);
builder
    .AddProject<GarminTools_Api>("GarminToolsApi")
    .WithUrl("/swagger", "Swagger");

builder.Build().Run();