using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignCPA.DAL;
using SignCPA.Models;

namespace SignCPA.Controllers
{
    public class HomeController : Controller
    {
        private static SignDAL signDal=new SignDAL();
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public JsonResult AddSign(Sign sign)
        {
            sign.SignTime=sign.CreateTime=sign.ModifyTime= DateTime.Now;
            sign.Content = sign.Content ?? "";
            var res = signDal.AddSign(sign);
            if (res > 0)
            {
                return Json(new {flag = "1", content = "打卡成功啦！棒棒哒！"}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { flag = "0", content = "sorry,出错啦，请联系程序员大胖~~！" }, JsonRequestBehavior.AllowGet);
        }
    }
}