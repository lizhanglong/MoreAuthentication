﻿using System;
using DevZH.AspNetCore.Authentication.XiaoMi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add XiaoMi authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class XiaoMiAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="XiaoMiMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables XiaoMi authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="options">A <see cref="XiaoMiOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseXiaoMiAuthentication(this IApplicationBuilder app, XiaoMiOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<XiaoMiMiddleware>(Options.Create(options));
        }

        /// <summary>
        /// Adds the <see cref="XiaoMiMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables XiaoMi authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseXiaoMiAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<XiaoMiMiddleware>();
        }
    }
}
