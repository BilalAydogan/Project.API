namespace Project.Web.Code
{
    public class Repo
    {
        public static class Session
        {
            public static string? Id
            {
                get
                {
                    string id = (new HttpContextAccessor()).HttpContext.Session.GetString("Id");
                    return id;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Id", value ?? ""); ;
                }
            }
            public static string? Email
            {
                get
                {
                    string email = (new HttpContextAccessor()).HttpContext.Session.GetString("Email");
                    return email;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Email", value ?? "");
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value ?? "");
                }
            }
            public static string? Rol
            {
                get
                {
                    string rol = (new HttpContextAccessor()).HttpContext.Session.GetString("Rol");
                    return rol;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Rol", value ?? "");
                }
            }
        }
    }
}
