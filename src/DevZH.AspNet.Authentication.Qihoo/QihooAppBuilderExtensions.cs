﻿using System;
using DevZH.AspNet.Authentication.Qihoo;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods to add Qihoo 360 authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class QihooAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="QihooMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Qihoo 360 authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="QihooOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseQihooAuthentication(this IApplicationBuilder app, QihooOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<QihooMiddleware>(options);
        }

        /// <summary>
        /// Adds the <see cref="QihooMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Qihoo 360 authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="configureOptions">An action delegate to configure the provided <see cref="QihooOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseQihooAuthentication(this IApplicationBuilder app, Action<QihooOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new QihooOptions();
            configureOptions?.Invoke(options);
            return app.UseQihooAuthentication(options);
        }
    }
}
