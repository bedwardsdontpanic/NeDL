export default class Utils  {

    public static formatUserName(userLogin?: string): string {
        if (!userLogin) {
            return "";
        }
        if (userLogin.indexOf('@') == -1) {
            return userLogin.toLocaleUpperCase();
        } else {
            return userLogin.split('@')[0].toLocaleUpperCase();
        }
    }

    public static delay(ms: number) {
        return new Promise( resolve => setTimeout(resolve, ms) );
    }
}