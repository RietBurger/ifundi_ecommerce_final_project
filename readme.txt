in an empty directory:

to create mvc app run this in terminal:
dotnet new mvc -o [your_project_name]


in terminal, type command: cd [project_name]
in terminal, run each of these commands on their own:
run this: dotnet add package MySQL
run this: dotnet add package MySQL.Data
run this: dotnet add package MySQL.Data.MySqlClient


// might not be necessary
add to .csproj file, after </PropertyGroup>, before </Project>: 
 <ItemGroup>
    <PackageReference Include ="MySqlConnector" Version ="0.61.0"/>
  </ItemGroup>


  to run the project in terminal:
  dotnet run .\Program.cs

  ctrl + click on link: http://localhost:[your localhost refnumber]

Go back to VS Code

stop the program from running in terminal by pressing CTRL + C


Adding a page:
1)
Go to controller: /Controllers/HomeController.cs

add:
public IActionResult Register()
        {
            return View();
        }

after last public entry ie: public IActionResult Privacy(){return view();}: 
*first one should be on line 25

2)
Go to location: 
/Views/Home/
right click on Home, select: new file
enter name: Register.cshtml


3)
Open file at location:
/Views/Shared/_Layout.cshtml

add this between asp-controller="Home" asp-action="Index" and  asp-controller="Home" asp-action="Privacy" in navbar list:
*might have to scroll to the right
<li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Register">Login</a>
                        </li>

 run project again by running command in terminal: dotnet run ./Program.cs

4)
/wwwroot/css/

add .css file: TBC

To stop the program in terminal from running: press CTRL + C

Create a model:
go to location
/Models
right click on Models, new file, name file: UserModel.cs



DB CONNECTION:

add using:
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

create connection string in Class:

add register(UserModel obj) ... 


















write pseudo code for:

speed in meters/second
speed in km/h
speed in miles/h

input distance in meters
input hour: 5
input minutes: 56
input seconds: 23

1 mile = 1609 meters

Main:
accept input: distance_meters
accept input: hour
accept input: minutes
accept input: seconds

distance_meters = 2500;
hour = 5;
minutes = 56;
seconds = 23;


convert hour to seconds
  hour * 60 * 60 = hr_second;
  5*60*60 = 18000;
convert minutes to seconds
  minutes * 60 = min_sec;
  56*60 = 3360;
// use seconds as is


add all seconds together
  hr_second + min_sec + seconds = total_seconds;
  18000 + 3360 + 23 = 21383;

convert all seconds to hours
  total_seconds / 60 / 60 = hours;
  21383 / 60 / 60 = ;

convert meters to miles:
  distance_meters * 1609 = miles;
  


calculate meter_per_second
  meter/seconds;
  2500/21383 = 0.1169;


















