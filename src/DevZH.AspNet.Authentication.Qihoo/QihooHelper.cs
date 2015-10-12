using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Qihoo
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Qihoo 360 after a successful authentication process.
    /// </summary>
    public static class QihooHelper
    {
        /// <summary>
        ///  360 �û�ID
        /// </summary>
        public static string GetId(JObject payload) => payload.Value<string>("id");

        /// <summary>
        ///  360 �û���
        /// </summary>
        public static string GetName(JObject payload) => payload.Value<string>("name");

        /// <summary>
        ///  360 �û�ͷ��
        /// </summary>
        public static string GetAvatar(JObject payload) => payload.Value<string>("avatar");
    }
}