﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Web_Client.Data.RequestDTO;
using Web_Client.Data.ResponseDTO;
using Web_Client.Data;
using Web_Client.Helpers;
using Web_Client.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Web_Client.Controllers
{
    public class AccountController : Controller
    {
        private string rootApiUrl;
        private IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            rootApiUrl = _configuration.GetSection("ApiUrls")["MyApi"];
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Gửi yêu cầu đăng nhập và nhận token từ back-end
            // Ví dụ: sử dụng HttpClient để gửi yêu cầu

            try
            {
                var client = new ClientService(HttpContext);
                var loginRequest = new LoginRequestDTO
                {
                    Username = username,
                    Password = password
                };

                string loginPath = rootApiUrl + "Account/Login";
                var sessionAccount = await client.Post<LoginResponseDTO>(loginPath, loginRequest);

                //var sessionAccount = await APIHelper.PostAsync<AuthenticationRequestDTO, AuthenticationResponseDTO>(APIEndpoints.APIEndpoints.AccountAPIEndpoints.LOGIN, authenticationRequestDTO, null);

                // If request to server failed or response model equal null
                if (sessionAccount == null)
                {
                    TempData["FailMessage"] = "Wrong password!!!";
                    return RedirectToAction("Login");
                }
                HttpContext.Session.SetObjectAsJson("sessionAccount", sessionAccount);

                var sessionRole = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount").Role;
                ViewBag.role = sessionRole;
                ViewBag.checkRoleAdmin = sessionRole.Equals("Admin");
                ViewBag.checkRoleSupplier = sessionRole.Equals("Supplier");
                ViewBag.checkRoleEmployee = sessionRole.Equals("Employee");

                if (sessionAccount.Role.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Supplier");
                }
                else if (sessionAccount.Role.Equals("Supplier"))
                {
                    return RedirectToAction("Index", "Order");
                }
                else if (sessionAccount.Role.Equals("Employee"))
                {
                    return RedirectToAction("Index", "Warehouse");
                }
                else
                {
                    return RedirectToAction("Unauthorized");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string repassword)
        {
            // Gửi yêu cầu đăng nhập và nhận token từ back-end
            // Ví dụ: sử dụng HttpClient để gửi yêu cầu

            try
            {
                var client = new ClientService(HttpContext);
                var registerRequest = new RegisterRequestDTO
                {
                    Username = username,
                    Password = password,
                    RePassword = repassword
                };
                string registerPath = rootApiUrl + "Account/Register";
                var registerAccount = await client.Post<ApiResponse>(registerPath, registerRequest);
                if (!registerAccount.IsSuccess)
                {
                    TempData["FailMessage"] = registerAccount.Message;
                    return RedirectToAction("Register");
                }

                var loginRequest = new LoginRequestDTO
                {
                    Username = username,
                    Password = password
                };

                string loginPath = rootApiUrl + "Account/Login";
                var loginAccount = await client.Post<LoginResponseDTO>(loginPath, loginRequest);

                //var sessionAccount = await APIHelper.PostAsync<AuthenticationRequestDTO, AuthenticationResponseDTO>(APIEndpoints.APIEndpoints.AccountAPIEndpoints.LOGIN, authenticationRequestDTO, null);

                // If request to server failed or response model equal null
                if (loginAccount == null)
                {
                    return RedirectToAction("Unauthorized");
                }

                HttpContext.Session.SetObjectAsJson("sessionAccount", loginAccount);

                if (loginAccount.Role.Equals("Supplier"))
                {
                    return RedirectToAction("Index", "Supplier");
                }
                else
                {
                    return RedirectToAction("Unauthorized");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
            }

            return View();
        }
    }
}
