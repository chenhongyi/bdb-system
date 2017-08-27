var Cookies = (function () {
    function Cookies() {
    }
    //设置token缓存
    Cookies.SetToken = function (token) {
        Cookies.access_token_update_time = new Date().getSeconds();
        Cookies.access_token = token;
    };
    //获取token缓存
    Cookies.GetToken = function () {
        var time = new Date().getSeconds();
        if (time - Cookies.access_token_update_time > 6000) {
            return "";
        }
        return Cookies.access_token;
    };
    //设置ticket缓存
    Cookies.SetTicket = function (ticket) {
        Cookies.ticket_update_time = new Date().getSeconds();
        Cookies.ticket = ticket;
    };
    //获取ticket缓存
    Cookies.GetTicket = function () {
        var time = new Date().getSeconds();
        if (time - Cookies.ticket_update_time > 6000) {
            return "";
        }
        return Cookies.ticket;
    };
    return Cookies;
}());
//# sourceMappingURL=cookie.js.map