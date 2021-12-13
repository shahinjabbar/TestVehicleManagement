using Microsoft.AspNetCore.Builder;

namespace VehicleManagament.API.Extensions.ExceptionMiddleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
