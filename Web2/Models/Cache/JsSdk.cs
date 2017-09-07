using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2.Models.Cache
{
    public static class JsSdk
    {
        /// <summary>
        /// token
        /// </summary>
        public static string Token { get; set; } = string.Empty;
        /// <summary>
        /// token上次更新时间
        /// </summary>
        public static long TokenUpdateTime { get; set; } = 0;


        /// <summary>
        /// 临时签名
        /// </summary>
        public static string Ticket { get; set; } = string.Empty;
        /// <summary>
        /// ticket上次更新时间
        /// </summary>
        public static long TicketUpdateTime { get; set; } = 0;


        /// <summary>
        /// 签名
        /// </summary>
        public static string Signature { get; set; } = string.Empty;
        /// <summary>
        /// 签名上次更新时间
        /// </summary>
        public static long SignatureUpdateTime { get; set; } = 0;
    }

    public class JsSdkToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class JsSdkTicket
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
