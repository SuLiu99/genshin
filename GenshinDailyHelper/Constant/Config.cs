namespace GenshinDailyHelper.Constant
{
    /// <summary>
    /// 常量设定
    /// </summary>
    public static class Config
    {
        public static string Ua = "Mozilla/5.0 (Linux; Android 5.1.1; f103 Build/LYZ28N; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/52.0.2743.100 Safari/537.36 miHoYoBBS/2.2.0";

        public static string AcceptEncoding = "gzip, deflate, br";

        #region Referer

        /// <summary>
        /// 活动ID，可能有变动
        /// </summary>
        public static string ActId = "e202009291139501";

        private static string BaseUrl = "https://webstatic.mihoyo.com/bbs/event/signin-ys/index.html";

        public static string RefererUrl =>
            BaseUrl + $"?bbs_auth_required=true&act_id={ActId}&utm_source=bbs&utm_medium=mys&utm_campaign=icon";

        #endregion

        #region API

        /// <summary>
        /// 获取账号信息
        /// </summary>
        public static string GetUserGameRolesByCookie = "binding/api/getUserGameRolesByCookie??";

        /// <summary>
        /// 获取签到信息
        /// </summary>
        public static string GetBbsSignRewardInfo = "event/bbs_sign_reward/info?";

        /// <summary>
        /// 开始签到
        /// </summary>
        public static string PostSignInfo = "event/bbs_sign_reward/sign?";

        #endregion
    }
}
