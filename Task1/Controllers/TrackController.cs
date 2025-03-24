using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackRepository _trackRepo;

        public TrackController(ITrackRepository trackRepo)
        {
            _trackRepo = trackRepo;
        }
        public ActionResult Index()
        {
            var tracks = _trackRepo.GetAll();
            return View(tracks);
        }


        public ActionResult Details(int id)
        {
            var track = _trackRepo.GetById(id);
            return View(track);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create(Track track)
        {
            try
            {
                if (track is not null)
                {
                    if (ModelState.IsValid)
                    {
                        _trackRepo.Add(track);
                        return RedirectToAction(nameof(Index));
                    }
                    return View(track);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(track);

        }


        public ActionResult Edit(int id)
        {
            var track = _trackRepo.GetById(id);
            return View(track);
        }


        [HttpPost]

        public ActionResult Edit(Track track)
        {
            try
            {
                if (track is not null)
                {

                    if (ModelState.IsValid)
                    {
                        if(_trackRepo.Update(track) >0)
                            return RedirectToAction(nameof(Index));

                    }
                }
                return View(track);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                
            }
            return View(track);

        }

   
        public ActionResult Delete(int id)
        {
            var track = _trackRepo.GetById(id);
            return View(track);
        }

  
        [HttpPost]
       
        public ActionResult Delete(Track track)
        {
            if(track is not null)
            {
                try
                {
                   if(_trackRepo.Delete(track) >0)
                     return RedirectToAction(nameof(Index));
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(track);
        
        }
    }
}
