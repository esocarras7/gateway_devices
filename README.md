## Project Title

Gateways Dashboard

### Description

This application is a web api that allows the management of gateways and their respective devices. It allows you to add new gateways, list all existing gateways, view the details of each gateway separately and add and remove devices to each gateway separately.

### Getting Started

Prerequisites:

1. .Net Core 3.1 SDK installed
2. The database is in-memory, so it does not require a database manager
3. VSCode or Visual Studio 2019 installed to be able to run the web api and debug if desired

### Installing

1. Download the project from https://github.com/esocarras7/gateway_devices
2. Run the following command:  
   dotnet build

### Executing program

1. Run the following command:  
   dotnet watch run
2. The web api raises in any of the following urls, by default the first url:  
   https://localhost:5001  
   http://localhost:5000
3. The web api endpoints are the following:
   - https://localhost:5001/api/gateway : all gateways (GET method)
   - https://localhost:5001/api/gateway/{id} : gateway by id (GET method)
   - https://localhost:5001/api/gateway : create new gateway (POST method)
   - https://localhost:5001/api/gateway/{id} : remove gateway (DELETE method)
   - https://localhost:5001/api/gateway/{id} : add device to gateway (PATCH method), json body format example:
     [
     {
     "op": "add",
     "path": "/devices/-",
     "value": {
     "vendor":"At&t",
     "createdDate":"2021-07-18T21:21:59.048361",
     "status":"Online"
     }
     }
     ]
   - https://localhost:5001/api/gateway/{id} : remove device from gateway (PATCH method), json body format example:
     [
     {
     "op": "remove",
     "path": "/devices/0"
     }
     ]

### Testing

1. In order to test the web api you must have one of the well-known tools for testing web apis such as:

- SoapUI
- Postman...
