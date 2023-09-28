// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace HamedStack.AspNetCore.Localization;

/// <summary>
/// Middleware for setting the current culture of a request based on the "Accept-Language" header.
/// </summary>
public class LocalizationMiddleware : IMiddleware
{
    /// <summary>
    /// Processes a request to set its culture based on the "Accept-Language" header.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
    /// <param name="next">The next delegate in the middleware pipeline.</param>
    /// <returns>A <see cref="Task"/> that completes when the middleware has processed the request.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the "Accept-Language" header is not provided or is null.</exception>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var cultureKey = context.Request.Headers["Accept-Language"].ToString();

        if (string.IsNullOrEmpty(cultureKey))
        {
            throw new ArgumentNullException(nameof(cultureKey), "The 'Accept-Language' header is not provided or is null.");
        }

        if (DoesCultureExist(cultureKey))
        {
            var culture = new CultureInfo(cultureKey);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        await next(context);
    }

    /// <summary>
    /// Checks if a given culture name exists in the system.
    /// </summary>
    /// <param name="cultureName">The name of the culture to check.</param>
    /// <returns>
    /// True if the culture exists in the system; otherwise, false.
    /// </returns>
    private static bool DoesCultureExist(string cultureName)
    {
        return CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Any(culture =>
                string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase)
            );
    }
}


