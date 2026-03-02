using GarminTools.Application.Handlers.Queries;
using GarminTools.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetUserDevicesQueryHandler).Assembly);
});

var defaultCorsPolicy = "DefaultCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: defaultCorsPolicy, policy =>
    {
        policy.SetIsOriginAllowed(origin =>
        {
            if (string.IsNullOrEmpty(origin)) return false;
            var host = new Uri(origin).Host;
            if (host is "localhost" or "myweb.local") return true;

            return origin is "https://jolly-grass-0b3ff2403.6.azurestaticapps.net" or "https://pmozola.github.io";
        });
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

        policy.AllowCredentials();
    });
});

builder.Services.AddInfrastructure();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(defaultCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.MapDefaultEndpoints();
app.Run();