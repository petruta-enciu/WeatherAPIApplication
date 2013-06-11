Weather API Application
=====================

 Weather application intend to offer and web API interface to clients.
 It is using Weather.com api to get weather information specific to a certain location (city/country).
 Information could be then are exported using configurable templates into xml/json format to diffrrent targets(shared storage, ftp server, cloud).
 
 Mood.Weather.Database - managed by Radu-Obreja, contains definitions for:
 - weather publisher (source), for example Weather.com
 - definitions used to manage locations used by clients
 - definitions used to manage configurable templates, configurable targets(shared storage, ftp server, cloud.
 
 Mood.Weather.Services - managed by Petru-Ciobanu, contains windows scheduled application used to read weather from weather publisher (source).
 
 Mood.Weather.Web - managed by Petruta-Enciu, contains web api service with client support used to export weather information according configurable templates and configurable targets(shared storage, ftp server, cloud).
