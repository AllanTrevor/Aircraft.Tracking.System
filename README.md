# Spotted Aircrafts Tracking System

## Prerequisits

- dotnet v5.0
- NodeJS >v14
- SQL Server >v2012
- Visual Studio >2019 (for API project)
- Visual Studio Code (for ReactJS app)

Excecute the script provided in [Scripts/db-feed.sql](Scripts/db-feed.sql) to create the Database & feed sample data.

## API Project

Execute below commands in [Source/Aircraft.Tracking.API](Source/Aircraft.Tracking.API) directory

### `dotnet restore`

### `dotnet build`

### `dotnet watch run`

Runs the app in the development mode withwatching file changes.\
Open [http://localhost:8080/swagger](http://localhost:8080/swagger) to view Swagger Page.

## Client App

Execute below commands in [Source/aircraft-tracking-web](Source/aircraft-tracking-web) directory

### `npm i`

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.


## Project Summery

Please refer to the [Project Summery](Docs/INFO.md) for information about the project & next steps.