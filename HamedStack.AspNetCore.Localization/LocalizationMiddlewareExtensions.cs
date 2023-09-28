// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace HamedStack.AspNetCore.Localization;

/// <summary>
/// Provides extension methods for configuring localization middleware.
/// </summary>
public static class LocalizationMiddlewareExtensions
{
    /// <summary>
    /// Configures the application to use request localization and custom localization middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="localizationOptions">Optional RequestLocalizationOptions. If not provided, defaults are used.</param>
    /// <returns>The application builder with localization middleware configured.</returns>
    public static IApplicationBuilder UseCustomLocalization(
        this IApplicationBuilder app,
        RequestLocalizationOptions? localizationOptions = null)
    {
        localizationOptions ??= new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"))
        };

        app.UseRequestLocalization(localizationOptions);
        app.UseStaticFiles();
        app.UseMiddleware<LocalizationMiddleware>();
        return app;
    }
}
