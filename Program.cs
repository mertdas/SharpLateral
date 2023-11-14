using RedPersist;
using System;
using System.Linq;

namespace SharpLateral
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (true)
            {
                Information.Banner();

            }

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: SharpLateral <command>");
                return;
            }

            string command = args[0];

            if (command == "redwmi")
            {
                // Example usage: Latrealmove redwmi 192.168.1.2 C:\myfile.exe
                RedWMI.Redwmi1(args.Skip(1).ToArray()); 
            }
            if (command == "redexec")
            {
                // Example usage: Latrealmove redexec 192.168.1.2 C:\localfile.exe C:\remotefile.exe MyServiceName
                RedExec.Redexec(args.Skip(1).ToArray());
            }
            if (command == "schedule")
            {
                Schedule.Schedule1(args.Skip(1).ToArray());
            }
            if (command == "reddcom")
            {
               RedDcom.Dcomexec(args.Skip(1).ToArray());
            }
            else 
            {
               //boom
            }
        }
    }
}
