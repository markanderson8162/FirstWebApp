using MyFIrstApp.Models;
using MyFIrstApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFIrstApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("login");
        }

        public ActionResult Login(UserModel userModel)
		{
            //return $"Results: User - {userModel.Username}. Password - {userModel.Password}";
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

			if (success)
			{
                return View("LoginSuccess", userModel);
			}
			else
			{
                return View("LoginFailure");
			}

		}
    }
}