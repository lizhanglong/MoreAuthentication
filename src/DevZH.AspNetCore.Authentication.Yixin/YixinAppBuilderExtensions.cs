﻿using System;
using DevZH.AspNetCore.Authentication.Yixin;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Yixin authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class YixinAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="YixinMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Yixin authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="YixinOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseYixinAuthentication(this IApplicationBuilder app, YixinOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<YixinMiddleware>(Options.Create(options));
        }

        /// <summary>
		/// Adds the <see cref="YixinMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Yixin authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseYixinAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<YixinMiddleware>();
        }
    }
}
