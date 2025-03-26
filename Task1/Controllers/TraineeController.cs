using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Controllers
{

    [Authorize]

    public class TraineeController : Controller
    {
        private readonly ITranieeRepository _tranieeRepo;
        private readonly ITrackRepository _trackRepo;

        public TraineeController(ITranieeRepository tranieeRepo, ITrackRepository trackRepo)
        {
            _tranieeRepo = tranieeRepo;
            _trackRepo = trackRepo;
        }
        public ActionResult Index()
        {
            var trainees = _tranieeRepo.GetAll();
            return View(trainees);
        }


        public ActionResult Details(int id)
        {
            var trainee = _tranieeRepo.GetById(id);
            return View(trainee);
        }


        public ActionResult Create()
        {
            ViewBag.AllTracks = _trackRepo.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainee trainee)
        {
            ViewBag.AllTracks = _trackRepo.GetAll();
            trainee.Trk = _trackRepo.GetById(trainee.TrackId);
            try
            {
                if (trainee is not null)
                {
                    if (ModelState.IsValid)
                    {
                        _tranieeRepo.Add(trainee);
                        return RedirectToAction(nameof(Index));


                    }
                }
                return View(trainee);

            }
            catch
            {
                return View(trainee);
            }
        }


        public ActionResult Edit(int id)
        {
            ViewBag.AllTracks = _trackRepo.GetAll();
            var trainee = _tranieeRepo.GetById(id);
            return View(trainee);
        }


        [HttpPost]

        public ActionResult Edit(Trainee trainee)
        {
            ViewBag.AllTracks = _trackRepo.GetAll();
            try
            {
                if (trainee is not null)
                {
                    if (ModelState.IsValid)
                    {
                        if (_tranieeRepo.Update(trainee) > 0)
                            return RedirectToAction(nameof(Index));


                    }
                }
                return View(trainee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(trainee);

        }


        public ActionResult Delete(int id)
        {
            var trainee = _tranieeRepo.GetById(id);
            return View(trainee);
        }

        [HttpPost]
        public ActionResult Delete(Trainee trainee)
        {
            try
            {
                if (trainee is not null)
                {
                    if (_tranieeRepo.Delete(trainee) > 0)
                        return RedirectToAction(nameof(Index));
                        
                    return View(trainee) ;
                    
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return View(trainee);

        }
    }
}
