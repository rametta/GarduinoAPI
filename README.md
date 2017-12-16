# Garduino API

- The Garduino API was designed as an interface for CRUD operations on a home garden monitoring system.

- The API includes many features such as:
  + Swagger Documentation on all routes
  + AutoQuery for retrieving certain properties of responses
  + AutoQuery UI for browsing DB data leveraging the flexibility of  ServiceStack AutoQuery
  + Helpfull HTTP error messages
  + Completely supports .Net Core to be ran as a Docker image
  + Runs on SQLite
  + Secure Authentication

- Docker commands
 + Build: `docker build -t garduinoapi .`
 + Run: `docker run -d -p 8080:80 --name garduinoapi garduinoapi`