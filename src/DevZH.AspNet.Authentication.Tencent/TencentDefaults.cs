﻿namespace DevZH.AspNet.Authentication.Tencent
{
    public static class TencentDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Tencent";
        // 获取授权码的链接
        public static readonly string AuthorizationEndpoint = "https://graph.qq.com/oauth2.0/authorize";
        // 获取相关身份令牌的链接
        public static readonly string TokenEndpoint = "https://graph.qq.com/oauth2.0/token";
        // 获取 OpenID 的链接
        public static readonly string OpenIdEndpoint = "https://graph.qq.com/oauth2.0/me";
        // 获取 用户基本信息 的链接
        public static readonly string UserInformationEndpoint = "https://graph.qq.com/user/get_user_info";
    }
}
