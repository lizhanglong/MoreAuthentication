﻿using System;
using DevZH.AspNetCore.Authentication.Tencent;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Tencent authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class TencentAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="TencentMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Tencent authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="TencentOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseTencentAuthentication(this IApplicationBuilder app, TencentOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<TencentMiddleware>(Options.Create(options));
        }

        /// <summary>
		/// Adds the <see cref="TencentMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Tencent authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseTencentAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<TencentMiddleware>();
        }
    }
}
