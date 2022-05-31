using Microsoft.OpenApi.Models;

using Notification.Api.Authentication;
using Notification.Api.Models;
using Notification.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<INotificationService, NotificationHubService>();

builder.Services.AddOptions<NotificationHubOptions>()
        .Configure(builder.Configuration.GetSection("NotificationHub").Bind)
        .ValidateDataAnnotations();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = ApiKeyAuthOptions.DefaultScheme;
    options.DefaultChallengeScheme = ApiKeyAuthOptions.DefaultScheme;
}).AddApiKeyAuth(builder.Configuration.GetSection("Authentication").Bind);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "ApiKey",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey",
        Description = "API Key",
        Reference = new OpenApiReference
        {
            Id = SecuritySchemeType.ApiKey.ToString(),
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(name: securityScheme.Reference.Id, securityScheme: securityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, Array.Empty<string>()}
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
