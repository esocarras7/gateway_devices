## Project Title

Gateways Dashboard

### Description

This application is a web api that allows the management of gateways and their respective devices. It allows you to add new gateways, list all existing gateways, view the details of each gateway separately and add and remove devices to each gateway separately.

### Getting Started

1. .Net Core 3.1 SDK installed
2. The database is in-memory, so it does not require a database manager

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

### Testing

1. In order to test the web api you must have one of the well-known tools for testing web apis such as:

- SoapUI
- Postman...
