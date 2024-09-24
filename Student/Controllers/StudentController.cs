using Student.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Students students)
        {
            var imageFile = Request.Files["ImagePath"]; 
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                
                var folderPath = Server.MapPath("~/Image/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Path.GetFileName(imageFile.FileName);
                var fullPath = Path.Combine(folderPath, fileName);
                imageFile.SaveAs(fullPath);

                
                ViewBag.ImagePath = fileName;
                students.ImagePath = fileName; 
            }

            
            TempData["StudentData"] = students;

           
            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
          
            Students students = TempData["StudentData"] as Students;

         
            if (students == null)
            {
                return RedirectToAction("Index");
            }

          
            return View(students);
        }
    }
}
