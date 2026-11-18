using System.Diagnostics;

namespace MVC_Project.Middleware
{
    public class RequestTime
    {
        private readonly RequestDelegate _next;
        public RequestTime(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var time = Stopwatch.StartNew();
            await _next.Invoke(context);
            time.Stop();

            Console.WriteLine($"{context.Request.Path} --> {time.Elapsed} ");
        }
    }
}
