using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http.Headers;
using Web_Client.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_Client.Data.ResponseDTO;
using Web_Client.Data;

namespace Web_Client.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            // Check if the action is one of the ignored actions
            if (actionName == "ErrorPage" || actionName == "Unauthorized")
            {
                base.OnActionExecuting(context);
                return;
            }

            // Check if the sessionAccount is null
            if (sessionAccount == null || !sessionAccount.Role.Equals(controllerName))
            {
                context.Result = RedirectToAction("Unauthorized");
            }

            base.OnActionExecuting(context);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Unauthorized()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Clear cache
            Response.Headers["Cache-Control"] = "no-cache, no-store";
            Response.Headers["Expires"] = DateTime.UtcNow.ToString("R");

            // Clear cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // Sign out user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        public void BuildTempDataMessage(ApiResponse apiResponse)
        {
            if (apiResponse != null && apiResponse.IsSuccess)
            {
                TempData["SuccessMessage"] = apiResponse.Message;
            }
            else
            {
                TempData["FailMessage"] = apiResponse.Message;
            }
        }

        public void BuildTempDataMessage(List<ApiResponse> apiResponse)
        {
            foreach (ApiResponse api in apiResponse)
            {
                if (api != null && api.IsSuccess)
                {
                    TempData["SuccessMessage"] = api.Message;
                }
                else
                {
                    TempData["FailMessage"] = api.Message;
                }
            }
        }
    }
}
