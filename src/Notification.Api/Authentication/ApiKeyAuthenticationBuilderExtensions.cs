using Microsoft.AspNetCore.Authentication;

namespace Notification.Api.Authentication;

public static class ApiKeyAuthenticationBuilderExtensions
{
    public static AuthenticationBuilder AddApiKeyAuth(
        this AuthenticationBuilder builder,
        Action<ApiKeyAuthOptions> configureOptions)
    {
        return builder
            .AddScheme<ApiKeyAuthOptions, ApiKeyAuthHandler>(
                ApiKeyAuthOptions.DefaultScheme,
                configureOptions);
    }

}
