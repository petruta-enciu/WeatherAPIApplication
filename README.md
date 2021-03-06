Weather API Application
=====================

Weather application intend to offer, through an web API interface, weather services to clients.
It is using Weather.com api to get weather information specific to a certain location (city/country).
Information are then exported using configurable templates into xml/json format to diffrrent targets(shared storage, ftp server, cloud).
 
### Mood.Weather.Database:
- managed by Radu-Obreja
- configurable weather publisher(source), for example Weather.com
- definitions used to manage locations used by clients
- definitions used to manage configurable templates, configurable targets(shared storage, ftp server, cloud)
 
Project is using live migrator pattern and was implemented by Radu-Obreja.

### Mood.Weather.Services:
- managed by Petru-Ciobanu
- contains windows scheduled application used to read weather from weather publisher(source)
- save weather data into a data storage
- optionally it could be configured to work as a service

Project architecture and its implementation was done by Petru-Ciobanu. 
  
### Mood.Weather.Web:
- managed by Petruta-Enciu
- contains web api interface used to perform DML instructions against data storage
- contains web api interface used to export weather information according configurable templates and configurable targets(shared storage, ftp server, cloud)
- contains web api client support which will be used by clients to access exposed services 

Project architecture and its implementation was done by Petruta-Enciu. 
Dapper CRUD repository design and implementation was done by Petruta-Enciu.

### Project deployment and tools:
 - Jenkins deployment build was made by Petru-Ciobanu
 - Weather database schema was design by Radu-Obreja
