class Cookies {
    private static access_token: string | null | undefined;   //微信token
    private static access_token_update_time: number | null | undefined;   //token更新时间


    private static ticket: string | null | undefined;         //微信ticket
    private static ticket_update_time: number | null | undefined;         //ticket更新时间

    constructor() {

    }
    //设置token缓存
    public static SetToken(token: string) {
        Cookies.access_token_update_time = new Date().getSeconds();
        Cookies.access_token = token;
    }

    //获取token缓存
    public static GetToken(): string {
        var time = new Date().getSeconds();
        if (time - Cookies.access_token_update_time > 6000) {
            return "";
        }
        return Cookies.access_token;
    }


    //设置ticket缓存
    public static SetTicket(ticket: string) {
        Cookies.ticket_update_time = new Date().getSeconds();
        Cookies.ticket = ticket;
    }

    //获取ticket缓存
    public static GetTicket(): string {
        var time = new Date().getSeconds();
        if (time - Cookies.ticket_update_time > 6000) {
            return "";
        }
        return Cookies.ticket;
    }
}