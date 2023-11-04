using System.Net;
using ClassicShopAPI.DTO;
using ClassicShopAPI.Exceptions;

namespace ClassicShopAPI.Middlewares;

/*
 * middleware : penengah antara request dari user dengan controller. jadi ketika ada request masuk, ditengah" aja yang ngejegat sebelum diterima oleh controller, itu yang disebut middleware
 *
 * middleware dijalankan sebelum dan setelah http request
 * filter dijalankan setelah middleware
 * 
 * next(context) : jadi kalau ada middleware selanjutnya, maka akan diarahkan
 * HttpContext : ini merupakan berbagai macam data yang bisa kita akses (Headers, Body, Dll). Response pun bisa ditangkap menggunakan context
 *
 * untuk handling exception ASP.NET Core ada 2 :
 * 1. filter (cara baru) : bisa dapet secara spesifik => exception yang dicegat
 * 2. middleware (cara lama) : yang didapet http => request/response
 *
 * sebenarnya bisa saja pakai if-else if. tetapi kalau ga mau ada if, jalan tengahnya pakai middleware
 *
 * kegunaan middleware :
 * - di JWT, misalnya kita mau ngambil headernya, bener atau tidak bearer yang dikirim tokennya itu valid. jadi kalau ga valid ga akan diteruskan kecontroller
 *
 * best practice :
 * untuk dotnet 6.0/7.0 => better menggunakan filters untuk handle exceptionnya
 * dibawah 6.0 => better middleware, karena ga punya filters juga
 *
 * di OCBC pakai dotnet 2.1 & reactjs
 * client enigma yang pake dotnet cuma 2 => OCBC dan ...
 *
 */

public class HandleExceptionMiddleware : IMiddleware
{
    // logger
    private readonly ILogger<HandleExceptionMiddleware> _logger;

    public HandleExceptionMiddleware(ILogger<HandleExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // _logger.LogInformation("Ini dari middleware");
        // await next(context);

        try
        {
            // mendapatkan response
            await next(context);
        }
        catch (NotFoundException e)
        {
            // custom response
            await HandleExceptionAsync(context, e);
        }
        catch (Exception e)
        {
            // custom response
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {

        // custom response
     
        var error = new Error
        {
            StatusCode = context.Response.StatusCode,
            Message = e.Message
        };

        switch (e)
        {
            case NotFoundException :
                error.StatusCode = (int) HttpStatusCode.NotFound;
                error.Message = e.Message;
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case not null :
                error.StatusCode = (int) HttpStatusCode.InternalServerError;
                error.Message = e.Message;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await context.Response.WriteAsJsonAsync(error);
    }
}