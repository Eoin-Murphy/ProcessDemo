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
    public class DefaultController : Controller
    {
        private IDataRepo dataRepo;

        public DefaultController()
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
    }
}