using System.Web;
using System.Web.SessionState;

namespace Utils
{
    /// <summary>
    /// AuthHelper 的摘要说明
    /// </summary>
    public static class AuthHelper
    {
        public static void AuthCheck(HttpSessionState session, HttpRequest request, HttpResponse response, HttpServerUtility server)
        {
            if (session["user"] == null)
                response.Redirect("~/Login.aspx?pre=" + server.UrlEncode(request.Url.AbsoluteUri));

        }
    }
}