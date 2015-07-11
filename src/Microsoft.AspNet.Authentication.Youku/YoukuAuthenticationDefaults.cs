﻿namespace Microsoft.AspNet.Authentication.Youku
{
    public class YoukuAuthenticationDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Youku";
        // 获取 授权码 的链接
        public const string AuthorizationEndpoint = "https://openapi.youku.com/v2/oauth2/authorize";
        // 获取相关 访问指令 的链接
        public const string TokenEndpoint = "https://openapi.youku.com/v2/oauth2/token";
        // 获取 用户基本信息 的链接
        public const string UserInformationEndpoint = "https://openapi.youku.com/v2/users/myinfo.json";
    }
}
