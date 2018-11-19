# FootballMatchResults
## This repository contains three projects
- FootballMatchResults.API
- FootballMatchResults.Dashboard
- FootballMatchResults.API.Tests

## Requirements
.NET Core SDK 2.1. You can download it from https://www.microsoft.com/net/download.

## How to get using git
- Open command prompt/terminal
- Navigate to desired folder where to clone the repository
- Run command `git clone https://github.com/OleksandrNefodov/FootballMatchResults.git

## How to run
### API & Dashboard
- Open command prompt/terminal etc.
- Navigate to desired project folder
- Run command `dotnet run`
- (If you want to use Dashboard you need to also run the API)
### Tests
- Open command prompt/terminal etc.
- Navigate to desired project folder
- Run command `dotnet test`

## FootballMatchResults.API
This project is a RESTful API that fetches football match results from external api.
The API supports GET, POST request method. Get returns all available match results on the resource.
Post - used for filtering data according to a date-range.
Accepted Content-Type: application/json

### Configuration
Dashboard and API are configured to listen different ports.
Application logging use NLog package and logs to file. File folder location can be changed in NLog.config file in the project.

### Get requests
### POST requests

## FootballMatchResults.Dashboard
This project is a Web application using ASP.NET Core MVC framework.
With this web application you can see the API in action.
In the UI you can execute all HTTP request methods mentioned above.

## MessageStore.API.Tests
This xunit test project to test the FootballMatchResults.API.
