﻿using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;

namespace Microsoft.AspNet.Authentication.Douban
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Douban Account service.
    /// </summary>
    public class DoubanAuthenticationMiddleware : OAuthAuthenticationMiddleware<DoubanAuthenticationOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="DoubanAuthenticationMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="options">Configuration options for the middleware.</param>
        public DoubanAuthenticationMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<ExternalAuthenticationOptions> externalOptions,
           [NotNull] IOptions<DoubanAuthenticationOptions> options,
           ConfigureOptions<DoubanAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options, configureOptions)
        {
            if (string.IsNullOrWhiteSpace(Options.ApiKey))
            {
                throw new ArgumentException($"参数 {nameof(Options.ApiKey)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.Secret))
            {
                throw new ArgumentException($"参数 {nameof(Options.Secret)} 值非法");
            }
            if(Options.Scope.Count == 0)
            {
                Options.Scope.Add("douban_basic_common");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="DoubanAuthenticationOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<DoubanAuthenticationOptions> CreateHandler()
        {
            return new DoubanAuthenticationHandler(Backchannel);
        }
    }
}
