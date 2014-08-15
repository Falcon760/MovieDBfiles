using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieMasterProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try { if (file.ContentLength > 0) 
        { var fileName = Path.GetFileName(file.FileName);
        int count = 0;
        if (count + 1 == 4) { count = 1; } 
            var path = Path.Combine(Server.MapPath("~/Content/images" + "/" + "asd" + count + ".jpg")); file.SaveAs(path); } 
            ViewBag.Message = "Upload successful"; return RedirectToAction("Index"); } 
        catch { ViewBag.Message = "Upload failed"; return RedirectToAction("Uploads"); } }
            //foreach (var file in files)
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Content/ImagesSlider"), fileName);
        //            file.SaveAs(path);
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}