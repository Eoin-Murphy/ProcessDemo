using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcessDemo.Models;
using ProcessDemo.MockRepo.Interfaces;
using ProcessDemo.MockRepo.BLL;

namespace ProcessDemo.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepo dataRepo;

        public HomeController()
        {
            dataRepo = new MockRepo.BLL.MockRepo();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(dataRepo.GetAllProcesses());
        }   
        
        [HttpGet]     
        public ActionResult AddJob()
        {
            return View("Index", dataRepo.NewJob());
        }

        [HttpGet]
        public ActionResult Progress()
        {
            return View("Index", dataRepo.SimulateProgression());
        }

        [HttpGet]
        public ActionResult Restart(int id)
        {
            return View("Index", dataRepo.StartJob(id));
        }

        [HttpGet]
        public ActionResult Pause(int id)
        {
            return View("Index", dataRepo.PauseJob(id));
        }
    }
}