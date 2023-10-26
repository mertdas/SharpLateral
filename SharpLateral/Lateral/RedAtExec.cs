using System;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace SharpLateral
{
    class Schedule
    { 
            public static void Schedule1(string[] args) { 
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: SharpLateral.exe schedule 192.168.31.134 C:\\windows\\system32\\notepad.exe ttt");
                return;
            }

            string taskName = args[2];
            string command = args[1];
            string remoteIp = args[0];

            string taskFullPath = $@"\{taskName}";

            using (TaskService ts = new TaskService(remoteIp))
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "My Scheduled Task";

                td.Triggers.Add(new DailyTrigger { DaysInterval = 1, StartBoundary = DateTime.Today.AddHours(10) });

                td.Actions.Add(new ExecAction(command, null, null));

                ts.RootFolder.RegisterTaskDefinition(taskFullPath, td);

                Task task = ts.GetTask(taskFullPath);
                task.Run();


                Console.WriteLine($"Scheduled task '{taskName}' created and started on remote machine {remoteIp}");

                ts.RootFolder.DeleteTask(taskName, false);

                Console.WriteLine($"Task '{taskName}' deleted succesfully");
            }

        }
    }
}