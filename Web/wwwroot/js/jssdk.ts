import "jweixin-1.2.0.js"

class JsSdk {
    constructor(){}
    public static version: string = "1.0";     //版本号
    public static appName: string = "";       //使用当前库的开发者,可以配置应用的名字
    public static isReady: boolean = false;      //微信JSSDK是否初始化完毕
    public static ticket: string = "";          //微信临时票据
    public static access_token: string = "";
    public init() {
        //验证是否存在微信的js组件
        //if (!wx) {

        //}

    }

    //获取令牌
    get_token() {
        JsSdk.access_token = Cookies.GetToken();
        if (JsSdk.access_token == "") {

        }
    }
}

class config {
    constructor() { }
    public static debug: boolean = true;    //开启调试模式,调用的所有api的返回值会在客户端alert打印出来,若要查看传入的参数,可以再pc端打开,参数信息会通过log打出,仅在pc端时才会打印
    public static appId: string = 'wxda49a56638ea1288';    //必填,公众号的id
    public static timestamp: string = Math.ceil(new Date().getTime() / 1000).toString();   //必填,生成签名的时间戳
    public static nonceStr: 'bdh987654321';       //必填,生成签名的随机串
    public static signature: string = '';                  //必填,签名
    public static jsApiList: string[] = [
        'checkJsApi',
        'getNetworkType',   //网络状态接口
        "getLocation",      //获取地理位置接口
        "openLocation"     //使用微信内置地图查看地理位置接口
    ];   //必填,需要使用的js接口列表,所有js接口列表见https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141115
}