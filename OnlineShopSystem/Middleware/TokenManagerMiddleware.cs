using System.Net;
using Newtonsoft.Json;
using Service.Interface;
using Infrastructure.ViewModel.Response;

namespace EDUHuB.API.Middleware
{
    public class TokenManagerMiddleware
    {
        private readonly RequestDelegate next;
        public IConfiguration Configuration { get; }
        public TokenManagerMiddleware(RequestDelegate next,IConfiguration configuration)
        {
            this.next = next;
            Configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext, ICacheService service)
        {
            string requestPath = httpContext.Request.Path.Value;
            string devEnvironment = Configuration["ConnectionString:DevelopmentEnvironment"];
            var body = httpContext.Request.Body;
            if (requestPath.Contains("swagger") || requestPath.Contains("index") ||
                requestPath.Contains("Login") || requestPath.Contains("RefreshToken") || requestPath.Equals("/") || requestPath.Contains("Files") 
                || devEnvironment == "1")
            {
                await this.next(httpContext);
            }
            else
            {
                try
                {
                    var authorization = httpContext.Request.Headers["authorization"];
                    string token = authorization.Single().Split(" ").Last().Trim();
                    var isAuthenticated = service.CheckToken(token);
                    
                    if (!isAuthenticated)
                    {
                        await Unauthorized(httpContext);
                    }
                    else
                    {
                        await this.next(httpContext);
                    }

                }
                catch (Exception ex)
                {
                    HandleErrorAsync(httpContext, ex);
                }


            }
        }

        public void HandleErrorAsync(HttpContext context, Exception exception)
        {
            var response = new { message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;

            var list = new List<string>();
            list.Add("401 Unauthorized");

            context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                code = (int)HttpStatusCode.Unauthorized,
                error = list
            }));
        }

        private async Task Unauthorized(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            var list = new List<string>();
            list.Add("401 Unauthorized");
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new FailureResponse
            {
                Code = (int)HttpStatusCode.Unauthorized,
              //  Error = list
            }));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenManagerMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenManagerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenManagerMiddleware>();
        }
    }

   
}
