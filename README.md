# Dr Sneuss' Factory

#### Latest version date 8/7/2020

#### By Deryck Jackson

## Description

A website for tracking which engineers are licensed to repair which machines

## User Stories

* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.
* As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.
* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed
* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.

## Specifications

| Spec | Input | Output |
| :---: | :---: | :---: |
| Program will create Engineer class with Name and Details property | Engineer { Name: Joe, Details: Lead } | Joe |
| Program will create a Machine class with Name and Details property | Machine { Name: Spot, Details: *woof* } | Spot |
| Program will display a list of all engineers | show engineers | Joe, Bob |
| Program will display a list of all machines | show machines | Spot, 1337 807 |

## Setup and Installation

* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* to clone this content, copy the url provided by the 'clone or download' button in GitHub
* Navigate to the newly created `Sneuss.Solution` folder
* Navigate to the `Sneuss` subfolder and run `dotnet restore`
* Run `dotnet ef database update` in the terminal
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser

## Tech used

* C#
* ASP.NET MVC
* Entity Framework Core
* MYSQL

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

Copyright (c) 2020 Deryck Jackson