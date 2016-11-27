using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCK_WebApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult ListMessage()
        {
            return View();
        }

        public ActionResult Conversation()
        {
            return View();
        }
    }
}