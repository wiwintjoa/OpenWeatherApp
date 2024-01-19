using Microsoft.AspNetCore.Mvc;
using OpenWeatherApp.Model;
using OpenWeatherApp.ServiceContract.Response;
using System.Collections.Generic;
using System.Linq;

namespace penWeatherApp.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IEnumerable<string> GetModelStateError()
        {
            return ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
        }

        protected JsonResult GetBasicSuccessJson()
        {
            return Json(new { IsSuccess = true });
        }

        protected JsonResult GetSuccessJson(BasicResponse response, object value)
        {
            return Json(new
            {
                IsSuccess = true,
                MessageInfoTextArray = response.GetMessageInfoTextArray(),
                Value = value
            });
        }

        protected JsonResult GetErrorJson(string[] messages)
        {
            return Json(new
            {
                IsSuccess = false,
                MessageErrorTextArray = messages
            });
        }

        protected JsonResult GetErrorJson(string message)
        {
            var messageArray = new[] { message };
            return Json(new
            {
                IsSuccess = false,
                MessageErrorTextArray = messageArray
            });
        }

        protected JsonResult GetErrorJson(BasicResponse response)
        {
            return Json(new
            {
                IsSuccess = false,
                MessageErrorTextArray = response.GetMessageErrorTextArray()
            });
        }

        protected IActionResult GetApiError(string[] errorMessages, int? httpStatusCode = null)
        {
            var actualStatusCode = httpStatusCode.HasValue ? httpStatusCode.Value : 400;
            var responseObj = new ApiErrorModel
            {
                ErrorMessages = errorMessages,
            };

            return this.StatusCode(actualStatusCode, responseObj);
        }

        [NonAction]
        protected virtual JsonResult Json(object data)
        {
            return new JsonResult(data);
        }
    }
}
