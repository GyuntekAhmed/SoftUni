namespace SIS.HTTP
{
    public enum HttpResponseCode
    {
        OK = 200,
        MovedPernamently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        Unauthorized = 4001,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
    }
}