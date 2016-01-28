﻿using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders;

namespace DevZH.AspNetCore.Authentication.XiaoMi
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Xiao Mi Account service.
    /// </summary>
    public class XiaoMiMiddleware : OAuthMiddleware<XiaoMiOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="XiaoMiMiddleware" />.
        /// </summary>
        /// <param name="next">The next middleware in the application pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        public XiaoMiMiddleware(
           RequestDelegate next,
           IDataProtectionProvider dataProtectionProvider,
           ILoggerFactory loggerFactory,
           IUrlEncoder encoder,
           IOptions<SharedAuthenticationOptions> sharedOptions,
           XiaoMiOptions options)
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

            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppId)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppSecret)} 值非法");
            }
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("1");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler{TOptions}" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler{TOptions}" /> configured with the <see cref="XiaoMiOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<XiaoMiOptions> CreateHandler()
        {
            return new XiaoMiHandler(Backchannel);
        }
    }
}
