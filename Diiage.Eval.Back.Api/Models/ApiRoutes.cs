namespace Diiage.Eval.Back.Api.Models;

public static class ApiRoutes
{
    private const string BaseApiRoutes = "api/v1/";

    public static class Applications
    {
        public const string BaseRoute = BaseApiRoutes + "applications/";
    }

    public static class Passwords
    {
        public const string BaseRoute = BaseApiRoutes + "passwords/";
        public const string ById = BaseRoute + "{id:int}/";
    }
}