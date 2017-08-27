using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP;
using Senparc.Weixin.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senparc.Weixin.Exceptions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controllers
{
    public class MenuController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            GetMenuResult result = new GetMenuResult(new ButtonGroup());
            //初始化
            for (int i = 0; i < 3; i++)
            {
                var subButton = new SubButton();
                for (int j = 0; j < 5; j++)
                {
                    var singleButton = new SingleClickButton();
                    subButton.sub_button.Add(singleButton);
                }
            }

            return View(result);
        }


        public ActionResult GetToken(string appId, string appSecret)
        {
            try
            {
                //if (!AccessTokenContainer.CheckRegistered(appId))
                //{
                //    AccessTokenContainer.Register(appId, appSecret);
                //}
                // var result = CommonAPIs.CommonApi.GetToken(appId, appSecret);//AccessTokenContainer.GetTokenResult(appId);

                //也可以直接一步到位：
                var result = AccessTokenContainer.TryGetAccessToken(appId, appSecret);


                return Json(result);

            }
            catch (Exception ex)
            {

                //TODO:为简化代码，这里不处理异常（如Token过期）
                return Json(new { error = "执行过程发生错误！" + ex.Message });

            }
        }

        [HttpPost]
        public ActionResult CreateMenu(string token, GetMenuResultFull resultFull, MenuMatchRule menuMatchRule)
        {
            var useAddCondidionalApi = menuMatchRule != null && !menuMatchRule.CheckAllNull();
            var apiName = string.Format("使用接口：{0}。", (useAddCondidionalApi ? "个性化菜单接口" : "普通自定义菜单接口"));
            try
            {
                //重新整理按钮信息
                WxJsonResult result = null;
                IButtonGroupBase buttonGroup = null;
                if (useAddCondidionalApi)
                {
                    //个性化接口
                    buttonGroup = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetMenuFromJsonResult(resultFull, new ConditionalButtonGroup()).menu;

                    var addConditionalButtonGroup = buttonGroup as ConditionalButtonGroup;
                    addConditionalButtonGroup.matchrule = menuMatchRule;
                    result = Senparc.Weixin.MP.CommonAPIs.CommonApi.CreateMenuConditional(token, addConditionalButtonGroup);
                    apiName += string.Format("menuid：{0}。", (result as CreateMenuConditionalResult).menuid);
                }
                else
                {
                    //普通接口
                    buttonGroup = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetMenuFromJsonResult(resultFull, new ButtonGroup()).menu;
                    result = Senparc.Weixin.MP.CommonAPIs.CommonApi.CreateMenu(token, buttonGroup);
                }

                var json = new
                {
                    Success = result.errmsg == "ok",
                    Message = "菜单更新成功。" + apiName
                };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = string.Format("更新失败：{0}。{1}", ex.Message, apiName) };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
        }


        [HttpPost]
        public ActionResult CreateMenuFromJson(string token, string fullJson)
        {
            //TODO:根据"conditionalmenu"判断自定义菜单

            var apiName = "使用JSON更新";
            try
            {
                GetMenuResultFull resultFull = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMenuResultFull>(fullJson);

                //重新整理按钮信息
                WxJsonResult result = null;
                IButtonGroupBase buttonGroup = null;

                buttonGroup = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetMenuFromJsonResult(resultFull, new ButtonGroup()).menu;
                result = Senparc.Weixin.MP.CommonAPIs.CommonApi.CreateMenu(token, buttonGroup);

                var json = new
                {
                    Success = result.errmsg == "ok",
                    Message = "菜单更新成功。" + apiName
                };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = string.Format("更新失败：{0}。{1}", ex.Message, apiName) };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
        }

        public ActionResult GetMenu(string token)
        {
            try
            {
                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetMenu(token);
                if (result == null)
                {
                    return Json(new { error = "菜单不存在或验证失败！" });
                }
                return Json(result);
            }
            catch (WeixinMenuException ex)
            {
                return Json(new { error = "菜单不存在或验证失败：" + ex.Message }, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception ex)
            {
                return Json(new { error = "菜单不存在或验证失败：" + ex.Message }, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
        }

        public ActionResult DeleteMenu(string token)
        {

            try
            {
                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.DeleteMenu(token);
                var json = new
                {
                    Success = result.errmsg == "ok",
                    Message = result.errmsg
                };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = ex.Message };
                return Json(json, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
        }
    }
}
