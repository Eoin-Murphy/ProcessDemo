using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessDemo.Models
{
    public class ProcessDataViewModel
    {
        public ProcessDataViewModel()
        {
            DataItems = new List<ProcessDataItemViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public List<ProcessDataItemViewModel> DataItems { get; set; }
    }

    public class ProcessDataItemViewModel
    {
        public string Status { get; set; }
    }
}