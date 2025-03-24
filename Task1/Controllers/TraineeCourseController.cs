using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Controllers
{
    public class TraineeCourseController : Controller
    {
        private readonly ITraineeCourseRepository _traineeCourseRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly ITranieeRepository _traineeRepo;

        public TraineeCourseController(ITraineeCourseRepository traineeCourseRepo, ICourseRepository courseRepo, ITranieeRepository traineeRepo)
        {
            _traineeCourseRepo = traineeCourseRepo;
            _courseRepo = courseRepo;
            _traineeRepo = traineeRepo;
        }
        public ActionResult Index()
        {
            var traineeCourse = _traineeCourseRepo.GetAll();
            return View(traineeCourse);
        }





        public ActionResult Create()
        {
            ViewBag.Trainess = _traineeRepo.GetAll();
            ViewBag.Courses = _courseRepo.GetAll();
            return View();
        }

        [HttpPost]

        public ActionResult Create(TraineeCourse traineeCourse)
        {
            ViewBag.Trainess = _traineeRepo.GetAll();
            ViewBag.Courses = _courseRepo.GetAll();
            try
            {
                if (traineeCourse is not null)
                {
                    if (_traineeCourseRepo.RegisterStudentToCourse(traineeCourse) > 0)
                        return RedirectToAction(nameof(Index));
                }
                return View(traineeCourse);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(traineeCourse);

        }


        public ActionResult Edit(int traineeId, int courseId)
        {
            ViewBag.Trainess = _traineeRepo.GetAll();
            ViewBag.Courses = _courseRepo.GetAll();
            var traineeCourse = _traineeCourseRepo.Get(traineeId, courseId);
            return View(traineeCourse);
        }


        [HttpPost]

        public ActionResult Edit(TraineeCourse traineeCourse)
        {
            try
            {
                if (traineeCourse is not null)
                {
                    if (_traineeCourseRepo.Update(traineeCourse) > 0)
                        return RedirectToAction(nameof(Index));
                }
                return View(traineeCourse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(traineeCourse);

        }


        public ActionResult Delete(int traineeId, int courseId)
        {
            ViewBag.Trainess = _traineeRepo.GetAll();
            ViewBag.Courses = _courseRepo.GetAll();

            var traineeCourse = _traineeCourseRepo.Get(traineeId, courseId);
            return View(traineeCourse);

        }

        
        [HttpPost]

        public ActionResult Delete(TraineeCourse traineeCourse)
        {
            ViewBag.Trainess = _traineeRepo.GetAll();
            ViewBag.Courses = _courseRepo.GetAll();
            try
            {
                if (traineeCourse is not null)
                {
                    _traineeCourseRepo.UnRegisterStudentToCourse(traineeCourse);
                    return RedirectToAction(nameof(Index));
                }
                return View(traineeCourse);
            }
            catch
            {
                return View(traineeCourse);
               
            }
            
        }
    }
}
