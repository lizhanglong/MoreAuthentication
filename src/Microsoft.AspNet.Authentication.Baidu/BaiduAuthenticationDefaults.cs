﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Baidu
{
    public static class BaiduAuthenticationDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Baidu";
        // 认证及获取临时 code 的链接
        public const string AuthorizationEndpoint = "https://openapi.baidu.com/oauth/2.0/authorize";
        // 获取 token 及 refresh token 的链接
        public const string TokenEndpoint = "https://openapi.baidu.com/oauth/2.0/token";
        // 获取用户基本信息，如 ID ，姓名等，可用来与本站 ID 进行配对
        // public const string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getInfo";
        public const string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser";
    }
}
