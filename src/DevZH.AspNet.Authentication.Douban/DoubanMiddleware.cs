﻿using System;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;

namespace DevZH.AspNet.Authentication.Douban
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Douban Account service.
    /// </summary>
    public class DoubanMiddleware : OAuthMiddleware<DoubanOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="DoubanMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        public DoubanMiddleware(
           RequestDelegate next,
           IDataProtectionProvider dataProtectionProvider,
           ILoggerFactory loggerFactory,
           IUrlEncoder encoder,
           IOptions<SharedAuthenticationOptions> sharedOptions,
           DoubanOptions options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

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
		/// Provides the <see cref="AuthenticationHandler{TOptions}" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler{TOptions}" /> configured with the <see cref="DoubanOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<DoubanOptions> CreateHandler()
        {
            return new DoubanHandler(Backchannel);
        }
    }
}
