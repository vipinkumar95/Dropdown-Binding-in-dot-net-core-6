using Bindingdropdown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Bindingdropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            StudentModel student = new StudentModel();
            student.StudentList = new List<SelectListItem>();

            var data = db.Students.ToList();

            student.StudentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });

            foreach (var item in data) 
            {
                student.StudentList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }


            return View(student);
        }

        
    }
}
