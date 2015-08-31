using System;
using System.Collections.Generic;
using System.Linq;
using ProcessDemo.MockRepo.Interfaces;
using ProcessDemo.Models;

namespace ProcessDemo.MockRepo.BLL
{
    public class MockRepo : IDataRepo
    {
        private static List<ProcessDataViewModel> processes;

        private const string queued = "queued";
        private const string inprocess = "inprocess";
        private const string paused = "paused";
        private const string completed = "completed";

        public List<ProcessDataViewModel> GetAllProcesses()
        {
            Initialize();

            return processes;
        }

        public List<ProcessDataViewModel> SimulateProgression()
        {
            Initialize();

            var nextProcess = processes.Where(p => p.Status == queued || p.Status == inprocess ).FirstOrDefault();

            if(nextProcess != null)
            {
                var nextDataItem = nextProcess.DataItems.Where(p => p.Status != completed).FirstOrDefault();

                if(nextDataItem != null)
                {
                    nextDataItem.Status = completed;

                    if(!nextProcess.DataItems.Any(i => i.Status == queued || i.Status == inprocess ))
                    {
                        nextProcess.Status = completed;
                    }
                    else
                    {
                        nextProcess.Status = inprocess;
                    }
                }
            }

            return processes;
        }

        public List<ProcessDataViewModel> NewJob()
        {
            Initialize();

            var newId = processes.Max(p => p.Id) + 1;
            var processData = new ProcessDataViewModel
            {
                Id = newId,
                Name = "Process " + newId,
                Status = queued
            };

            for (int j = 0; j < 5; j++)
            {
                var processDataItem = new ProcessDataItemViewModel
                {
                    Status = queued
                };

                processData.DataItems.Add(processDataItem);
            }

            processes.Add(processData);

            return processes;
        }

        public List<ProcessDataViewModel> PauseJob(int processId)
        {
            Initialize();

            var process = processes.Where(p => p.Id == processId).SingleOrDefault();

            if(process != null)
            {
                process.Status = paused;
            }

            return processes;
        }

        public List<ProcessDataViewModel> StartJob(int processId)
        {
            Initialize();

            var process = processes.Where(p => p.Id == processId).SingleOrDefault();

            if (process != null)
            {
                process.Status = queued;
            }

            return processes;
        }

        private static void Initialize()
        {
            if (processes == null)
            {
                processes = BuildDummyData(10, 10);
            }
        }

        private static List<ProcessDataViewModel> BuildDummyData(int processCount, int processItemCount)
        {
            var result = new List<ProcessDataViewModel>();
            for (int i = 0; i <= processCount; i++)
            {
                var processData = new ProcessDataViewModel
                {
                    Id = i,
                    Name = "Process " + i,
                    Status = queued
                };

                for (int j = 0; j < processItemCount; j++)
                {
                    var processDataItem = new ProcessDataItemViewModel
                    {
                        Status = queued
                    };

                    processData.DataItems.Add(processDataItem);
                }

                result.Add(processData);
            }

            return result;
        }
    }
}