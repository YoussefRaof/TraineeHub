using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public ActionResult Index()
        {
            var Courses = _courseRepo.GetAll();
            return View(Courses);
        }

     
        public ActionResult Details(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }

      
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
    
        public ActionResult Create(Course course)
        {
            try
            {
                if (course is not null && ModelState.IsValid)
                {
                    if (_courseRepo.Add(course) > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(course);
        }

        
        public ActionResult Edit(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }

     
        [HttpPost]
   
        public ActionResult Edit(Course course)
        {
            try
            {
                if (course is not null && ModelState.IsValid)
                {
                    if (_courseRepo.Update(course) > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(course);
        }

       
        public ActionResult Delete(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }

      
        [HttpPost]
      
        public ActionResult Delete(Course course)
        {
            try
            {
                if (course is not null )
                {
                    if (_courseRepo.Delete(course) > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(course);
        }
    }
}
