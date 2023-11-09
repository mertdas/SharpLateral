# SharpLateral

#Compiling Project

Below 3rd party libraries are used in this project.

TaskScheduler
https://github.com/dahall/TaskScheduler
Fody
https://github.com/Fody/Fody

Load the Visual Studio project up and go to "Tools" > "NuGet Package Manager" > "Package Manager Settings"
Open "NuGet Package Manager" > "Package Sources"

Install the Fody
Install-Package Costura.Fody -Version 3.3.3

Install the Taskscheduler
Install-Package TaskScheduler -Version 2.8.11
