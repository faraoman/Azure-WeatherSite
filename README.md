# WeatherSite
R&amp;D project for exploring Azure platform. This project inlude: Azure Container Registry,Azure Container Instance, Azure Sql Database, Azure Storage

## Prerequisites

This services must be configurated and running
 - Azure Resource Group
 - Azure Container Registry
 - Azure Sql Database with this settings:
   - Connectivity method set to Public Endpoin
   - Allow azure services and resources to access this server
   - Add current client IP address (only for allow connection from your ip)
 - Azure Storage

On Azure Sql Database, run the script `weatherForecastTable.sql`. This script create a new table called `tblWeatherForecast` and insert 3 new rows in it

## Step 1

Clone this repo

## Step 2

Change the Connection String for AzureSqlDatabase and AzureStorage located into appsettings.json file.

## Step 3

Publish this at Azure Container Registry using your Azure Account

## Step 4

Create a new Azure Container Instance using this container end configure it to have a public endpoint

## Step 5

ALL DONE! See this application running 
