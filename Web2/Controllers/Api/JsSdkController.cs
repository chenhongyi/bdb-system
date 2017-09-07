using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Web2.Models.Cache;
using Web2.Models;

namespace Web2.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/JsSdk/[action]")]
    public class JsSdkController : Controller
    {

        #region 微信token和缓存


        /// <summary>
        /// 微信token 7200秒过期,这里检查,如果超过了6000秒,就重新获取一次
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetWxToken()
        {
            DateTime now = DateTime.Now;
            var time = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(now);
            if (JsSdk.TokenUpdateTime == 0)
            {
                JsSdk.TokenUpdateTime = time;
            }
            if (time - JsSdk.TokenUpdateTime > 6000 || string.IsNullOrEmpty(JsSdk.Token))
            {
                await UpdateToken();
            }
            return JsSdk.Token;
        }


        /// <summary>
        /// 更新weixintoken 缓存6000秒
        /// </summary>
        async Task UpdateToken()
        {
            Uri url = new Uri("Https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential" + "&appid=" + DefineModel.AppId + "&secret=" + DefineModel.AppSecret);
            WebRequest request = WebRequest.Create(url);
            string content = string.Empty;
            // Return the response. 
            using (WebResponse response = await request.GetResponseAsync())
            {
                var steam = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(steam))
                {
                    content = sr.ReadToEnd();
                }
            }

            var s = JsonConvert.DeserializeObject<JsSdkToken>(content);
            if (s != null)
            {
                JsSdk.Token = s.access_token;
                JsSdk.TokenUpdateTime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            }
            return;
        }
        #endregion

        [HttpGet]
        public async Task<string> GetWxTicket()
        {
            if (string.IsNullOrEmpty(JsSdk.Token))
            {
                await UpdateToken();
            }

            DateTime now = DateTime.Now;
            var time = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(now);
            if (JsSdk.TicketUpdateTime == 0)
            {
                JsSdk.TicketUpdateTime = time;
            }
            if (time - JsSdk.TicketUpdateTime > 6000 || string.IsNullOrEmpty(JsSdk.Ticket))
            {
                await UpdateTicket();
            }
            return JsSdk.Ticket;
        }

        async Task UpdateTicket()
        {
            if (string.IsNullOrEmpty(JsSdk.Token))
            {
                await UpdateToken();
            }
            Uri url = new Uri("Https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + JsSdk.Token + "&type=jsapi");
            WebRequest request = WebRequest.Create(url);
            string content = string.Empty;
            // Return the response. 
            using (WebResponse response = await request.GetResponseAsync())
            {
                var steam = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(steam))
                {
                    content = sr.ReadToEnd();
                }
            }

            var s = JsonConvert.DeserializeObject<JsSdkTicket>(content);
            if (s != null)
            {
                JsSdk.Ticket = s.ticket;
                JsSdk.TicketUpdateTime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            }
            return;
        }

       
        /// <summary>
        /// 获取signatrue
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonceStr"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetWxSignature(string timestamp, string nonceStr, string url)
        {
            if (string.IsNullOrEmpty(JsSdk.Ticket))
            {
                await UpdateTicket();
            }
            string signature = string.Format(@"jsapi_ticket={0}&nonceStr={1}&timestamp={2}&url={3}", JsSdk.Ticket, nonceStr, timestamp, url);
            return Senparc.Weixin.Helpers.EncryptHelper.GetSha1(signature);
        }


        //// GET: api/JsSdk
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/JsSdk/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/JsSdk
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/JsSdk/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
