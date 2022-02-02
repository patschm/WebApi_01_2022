using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Background.Middleware
{
    public class MijnMiddleware
    {
        private readonly RequestDelegate _next;

        public MijnMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            //ctx.Request
            //ctx.
            System.Console.WriteLine("Incoming!!!!");
            await _next(ctx);
            System.Console.WriteLine("Outgoing!!!!");
            //ctx.Response
        }
    }

    static class MijnExtensions
    {
        public static IApplicationBuilder UseMijn(this IApplicationBuilder bld)
        {
            return bld.UseMiddleware<MijnMiddleware>();
        }
    }
}