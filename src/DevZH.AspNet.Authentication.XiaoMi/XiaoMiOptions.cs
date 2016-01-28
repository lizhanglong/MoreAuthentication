﻿using DevZH.AspNetCore.Authentication.Common;
using DevZH.AspNetCore.Authentication.XiaoMi;

namespace DevZH.AspNetCore.Builder
{
    public class XiaoMiOptions : OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public XiaoMiOptions()
        {
            AuthenticationScheme = XiaoMiDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-mi"; // implicit
            AuthorizationEndpoint = XiaoMiDefaults.AuthorizationEndpoint;
            TokenEndpoint = XiaoMiDefaults.TokenEndpoint;
            UserInformationEndpoint = XiaoMiDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  小米开放平台中用 AppId 来指代 ClientId
        /// </summary>
        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  小米开放平台中用 AppSecret 来指代 ClientSecret
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        /// <summary>
        ///  指示应用是否需要用户切换账号
        /// </summary>
        /// <value>true ： 应用不需要用户切换账号</value>
        /// <value>false ： 已登录用户会进入切换账号页面</value>
        public bool SkpConfirm { get; set; }

        /// <summary>
        ///  目前 小米开放平台只支持 MAC 认证模式，文档里说未来可能支持 Bearer，时间不定
        /// </summary>
        public TokenType TokenType { get; set; } = TokenType.MAC;
    }
}
