using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace notificationtest.Controllers
{
    public class FirebaseNotifController : Controller
    {
        // GET: FirebaseNotif
        public async Task<ActionResult> Index()
        {
            try
            {
                // The topic name can be optionally prefixed with "/topics/".
                var topic = "change_shift";//or see filter segments

                // See documentation on defining a message payload.
                var message = new Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Lorem ipsum",
                        Body = "Lorem ipsum and some more lorum ipsum."
                    },
                    Data = new Dictionary<string, string>()
                    {
                        { "id", "203436" },
                        { "type", "Shift Change" },
                        { "click_action", "FLUTTER_NOTIFICATION_CLICK"}
                    },
                    Topic = topic,
                };

                // Send a message to the devices subscribed to the provided topic.
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                // Response is a message ID string.
                response = "Successfully sent message: " + response;

                return Content(response);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
    }
}
