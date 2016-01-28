﻿using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders;

namespace DevZH.AspNetCore.Authentication.Youku
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using Youku.
    /// </summary>
    public class YoukuMiddleware : OAuthMiddleware<YoukuOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="YoukuMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
		/// <param name="options">Configuration options for the middleware.</param>
        public YoukuMiddleware(
           RequestDelegate next,
           IDataProtectionProvider dataProtectionProvider,
           ILoggerFactory loggerFactory,
           IUrlEncoder encoder,
           IOptions<SharedAuthenticationOptions> sharedOptions,
           YoukuOptions options)
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
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler{TOptions}" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler{TOptions}" /> configured with the <see cref="YoukuOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<YoukuOptions> CreateHandler()
        {
            return new YoukuHandler(Backchannel);
        }
    }
}
