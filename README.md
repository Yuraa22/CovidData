# This is ASP.NET Core app with SQlite database. 

Contains all covid data for Croatia collected from https://api.covid19api.com/dayone/country/croatia.

# Prerequisites

Installed Docker for Windows and started service

## Build app

docker-compose build (Windows)

## Starting up

docker-compose up

## Stopping up

docker-compose stop

## Available API

### view cases with total numbers of confirmed, recovered and deaths
- localhost:8888/api/casestotal
### view cases with daily numbers of confirmed, recovered and deaths
- localhost:8888/api/casesdaily
### variables: min, max (of confirmed cases), from, to (*any variable can be omitted)
### examples: 
- localhost:8888/api/casesdaily?min=5&max=30&from=2020-02-01T00:00:00&to=2020-05-01T00:00:00
- localhost:8888/api/casesdaily?min=5&max=30
- localhost:8888/api/casesdaily?max=30&from=2020-02-01T00:00:00&to=2020-05-01T00:00:00
- localhost:8888/api/casesdaily?from=2021-01-01T00:00:00
