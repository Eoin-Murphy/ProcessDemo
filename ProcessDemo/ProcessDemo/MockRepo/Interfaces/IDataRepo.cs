using System.Collections.Generic;
using ProcessDemo.Models;

namespace ProcessDemo.MockRepo.Interfaces
{
    interface IDataRepo
    {
        List<ProcessDataViewModel> GetAllProcesses();

        List<ProcessDataViewModel> SimulateProgression();

        List<ProcessDataViewModel> NewJob();

        List<ProcessDataViewModel> PauseJob(int processId);

        List<ProcessDataViewModel> StartJob(int processId);
    }
}
