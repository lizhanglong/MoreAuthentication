﻿using Microsoft.AspNet.Authentication.Youku;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="YoukuMiddleware" />
    /// </summary>
    public static class YoukuAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using Youku.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYoukuAuthentication([NotNull] this IApplicationBuilder app, Action<YoukuOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<YoukuMiddleware>(
                 new ConfigureOptions<YoukuOptions>(configureOptions ?? (o => { })));
        }
    }
}
