﻿using System;
using DevZH.AspNetCore.Authentication.Sina;
using Microsoft.AspNetCore.Builder;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Sina authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class SinaAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="SinaMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Sina authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="SinaOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseSinaAuthentication(this IApplicationBuilder app, SinaOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<SinaMiddleware>(options);
        }

        /// <summary>
		/// Adds the <see cref="SinaMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Sina authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="configureOptions">An action delegate to configure the provided <see cref="SinaOptions"/>.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseSinaAuthentication(this IApplicationBuilder app, Action<SinaOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            var options = new SinaOptions();
            configureOptions(options);
            return app.UseMiddleware<SinaMiddleware>(options);
        }
    }
}
