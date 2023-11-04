using ClassicShopAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClassicShopAPI.FIlters;

public class HandleException : IExceptionFilter
{

    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case NotFoundException :
                context.Result = new NotFoundResult();
                break;
        }
    }
}