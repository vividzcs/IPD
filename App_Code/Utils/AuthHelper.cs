using System.Web;
using System.Web.SessionState;
using Models;

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


        public static void TeacherOnlyPage(HttpSessionState session, HttpRequest request, HttpResponse response,
            HttpServerUtility server)
        {
            if (!(session["user"] is Teacher))
            {
                session.RemoveAll();
                response.Redirect("/Login.aspx");
            }
        }
        public static void AdminOnlyPage(HttpSessionState session, HttpRequest request, HttpResponse response,
            HttpServerUtility server)
        {
            if (!(session["user"] is Admin))
            {
                session.RemoveAll();
                response.Redirect("/Login.aspx");
            }
        }
        public static void StudentOnlyPage(HttpSessionState session, HttpRequest request, HttpResponse response,
            HttpServerUtility server)
        {
            if (!(session["user"] is Student))
            {
                session.RemoveAll();
                response.Redirect("/Login.aspx");
            }
        }
    }
}