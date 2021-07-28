using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFIrstApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestView()
		{
            //should return 'testview.cshtml'
            return View();
		}

        public string PrintMessage()
		{
            return "<h1>Welcome</h1><p>Custom page</p>";
		}

        public string PrintError()
		{
            return "<h1>ERROR</h1><h3>You made it to this page by accident.</h3>";
		}

        public string Welcome(string name, int numTimes = 1)
		{
            return HttpUtility.HtmlEncode($"Hello {name}. Number of times: {numTimes}");

		}

        public string Welcome2(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode($"Hello {name}. ID: {ID}");

        }
    }
}