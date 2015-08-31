using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcessDemo.Models;

namespace ProcessDemo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var viewData = BuildDummyData(10, 10);

            return View(viewData);
        }

        private List<ProcessDataViewModel> BuildDummyData(int processCount, int processItemCount )
        {
            var result = new List<ProcessDataViewModel>();
            for(int i =0; i <= processCount; i++)
            {
                var processData = new ProcessDataViewModel
                {
                    Id = i.ToString(),
                    Name = "Process " + i,
                    Status = i % 2 == 0 ? "Completed" : "Queued"
                };

                for(int j = 0; j < processItemCount; j++)
                {
                    var processDataItem = new ProcessDataItemViewModel
                    {
                        Status = j % 2 == 0 ? "Completed" : "Queued"
                    };

                    processData.DataItems.Add(processDataItem);
                }

                result.Add(processData);
            }

            return result;
        }
    }
}