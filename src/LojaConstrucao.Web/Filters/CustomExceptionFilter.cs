using LojaConstrucao.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LojaConstrucao.Web.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider _modelMetaDataProvider;

        // public CustomExceptionFilter(IModelMetadataProvider modelMetaDataProvider)
        // {
        //     _modelMetaDataProvider = modelMetaDataProvider;
        // }

        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-width"] == "XMLHttpRequest";

            if(isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                var message = context.Exception is DomainException? context.Exception.Message : "An error ocurred";
                context.Result = new JsonResult(message);
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}