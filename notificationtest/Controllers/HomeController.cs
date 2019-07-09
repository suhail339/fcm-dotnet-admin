using OneSignal.CSharp.SDK;
using OneSignal.CSharp.SDK.Resources;
using OneSignal.CSharp.SDK.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace notificationtest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string response = "FirebaseNotif,OneSignalNotif sample implementation available.";
            return Content(response);

        }
    }
}