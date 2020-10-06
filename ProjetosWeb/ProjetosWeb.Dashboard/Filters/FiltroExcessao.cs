using System;
using System.Web.Mvc;

namespace ProjetosWeb.Dashboard.Filters
{
    public class FiltroExcessao : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is NotImplementedException)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/PageNotFound.cshtml"
                };
            }
            base.OnException(filterContext);
        }
    }
}