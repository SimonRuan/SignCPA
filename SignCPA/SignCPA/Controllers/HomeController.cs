using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignCPA.DAL;
using SignCPA.Models;
using SignCPA.Helper;

namespace SignCPA.Controllers
{
    public class HomeController : Controller
    {
        private static SignDAL signDal = new SignDAL();
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// 新增打卡记录
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddSign(Sign sign)
        {

            var time = DateTime.Now;
            if (time.Hour < 3)  //如果签到时间在凌晨0点到3点之间，那学习时间其实是前一天
            {
                time = time.AddHours(-12);
            }
            sign.SignTime = sign.CreateTime = sign.ModifyTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            sign.Content = sign.Content ?? "";
            sign.Color = EnumHelper.ToColor(sign.DoneLevel);
            var res = signDal.AddSign(sign);
            if (res > 0)
            {
                return Json(new { flag = "1", content = "打卡成功啦！棒棒哒！" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { flag = "0", content = "sorry,出错啦，请联系程序员大胖~~！" }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取所有打卡记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllSigns()
        {
            List<Sign> res = signDal.GetAllSigns();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}