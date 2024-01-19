using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using OpenWeatherApp.Model;

namespace OpenWeatherApp.Infrastructure
{
    public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            var responseObj = new ApiErrorModel
            {
                ErrorMessages = new string[] { context.Message },
            };

            var response = new ObjectResult(responseObj);
            response.StatusCode = 400;

            return response;
        }
    }
}
