using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using MyApi;

namespace Background.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MyFirstFilterAttribute : ActionFilterAttribute
    {
        private readonly ICounter _svc;

        public MyFirstFilterAttribute(ICounter svc)
        {
            _svc = svc;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            System.Console.WriteLine("Na het genereren va het result");
            base.OnResultExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            System.Console.WriteLine("Voordat we het result gaan genereren");
            base.OnResultExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _svc.Increment();
            System.Console.WriteLine("Naddat we de action hebben uitgevoerd");
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _svc.Increment();
            System.Console.WriteLine("Voordat we de action gaan uitvoeren");
            base.OnActionExecuting(context);
        }
    }
}