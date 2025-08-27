TEG.Test Solution

Overview:
This solution contains a Web MVC application and a Web API for managing and displaying events and venues. 
The architecture is layered with separate projects for business logic, infrastructure, and unit tests.

Web Application:
- Default Venue List Page: http://3.107.249.86:5001
- Event Calendar per Venue Page: http://3.107.249.86:5001/Events/ByVenue/10029

The MVC application (TEG.Test.Web) consumes the API to display venue and event data.

API Endpoints:
Base URL: http://3.107.249.86:5000/api

- /venues : Get all venues
- /venues/{id} : Get venue data by ID
- /venues/10029/events : Get events for a specific venue
- /events : Get all events
- /events/{id} : Get event by ID

Note: URLs may not work if the EC2 instance has been terminated.

Hosting:
- Both the MVC and API projects are hosted in IIS on an EC2 instance.
- The applications run on ports 5000 (API) and 5001 (Web MVC) by default.

Project Structure:
- TEG.Test.Web : MVC project – the web front-end
- TEG.Test.API : Web API – provides data to the MVC application
- TEG.Test.Application : Contains business logic
- TEG.Test.Infrastracture : Implements data seeding and repository patterns for venues and events
- TEG.Test.UnitTest : Unit test project (optional, can be implemented in the future)

How to Run Locally:
1. In TEG.Test.Web appsettings.json, make sure the API Base URL points to your local API:
   "ApiSettings": {
     "BaseUrl": "https://localhost:7194"
   }
2. Configure Visual Studio to run both TEG.Test.Web and TEG.Test.API simultaneously.
3. Start debugging, and access the Web MVC application at https://localhost:5001 (or the port you configured).

Future Improvements:
- Implement unit tests for services and controllers.
- Apply authentication and authorization to the API.
- Upgrade the presentation layer with a modern UI framework (e.g., Blazor, React, or Vue).
