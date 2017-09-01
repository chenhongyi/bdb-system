"use strict";
exports.__esModule = true;
require("jweixin-1.2.0.js");
var JsSdk = (function () {
    function JsSdk() {
    }
    JsSdk.prototype.init = function () {
        //验证是否存在微信的js组件
        //if (!wx) {
        //}
    };
    //获取令牌
    JsSdk.prototype.get_token = function () {
        JsSdk.access_token = Cookies.GetToken();
        if (JsSdk.access_token == "") {
        }
    };
    return JsSdk;
}());
JsSdk.version = "1.0"; //版本号
JsSdk.appName = ""; //使用当前库的开发者,可以配置应用的名字
JsSdk.isReady = false; //微信JSSDK是否初始化完毕
JsSdk.ticket = ""; //微信临时票据
JsSdk.access_token = "";
var config = (function () {
    function config() {
    }
    return config;
}());
config.debug = true; //开启调试模式,调用的所有api的返回值会在客户端alert打印出来,若要查看传入的参数,可以再pc端打开,参数信息会通过log打出,仅在pc端时才会打印
config.appId = 'wxda49a56638ea1288'; //必填,公众号的id
config.timestamp = Math.ceil(new Date().getTime() / 1000).toString(); //必填,生成签名的时间戳
config.signature = ''; //必填,签名
config.jsApiList = [
    'checkJsApi',
    'getNetworkType',
    "getLocation",
    "openLocation" //使用微信内置地图查看地理位置接口
]; //必填,需要使用的js接口列表,所有js接口列表见https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141115
