using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminClientServices.Extensions
{
    interface IExceptionFilter: IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
