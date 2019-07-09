using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace notificationtest.Controllers
{
    public class OneSignalNotifController : Controller
    {
        // GET: OneSignalNotif
        public ActionResult Index()
        {
            string tok = ("token from one signal account");

            Guid AppId = new Guid("app id from one signal account");

            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + tok);

            var serializer = new JavaScriptSerializer();
            var obj = new
            {
                app_id = AppId,
                content_available = true,
                headings = new { en = "Sample Heading" },
                contents = new { en = "This is the sample message sent via push notifications by OneSignal." },
                filters = new object[] { new { field = "tag", key = "topic", value = "Company/1NDD5-110M3-DDD66-838BBH-110M3" } },
            };



            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string response = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var res = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                response = ex.Message;
            }

            return Content(response);

        }
    }
}