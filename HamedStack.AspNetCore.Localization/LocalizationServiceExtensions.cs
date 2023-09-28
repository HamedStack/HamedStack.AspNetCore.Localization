// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using HamedStack.Localization.JsonString;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace HamedStack.AspNetCore.Localization;

/// <summary>
/// Provides extension methods for configuring localization services.
/// </summary>
public static class LocalizationServiceExtensions
{
    /// <summary>
    /// Adds the JsonStringLocalizerFactory to the services collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection with JsonStringLocalizerFactory added.</returns>
    public static IServiceCollection AddJsonStringLocalizerFactory(this IServiceCollection services)
    {
        services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
        return services;
    }
}