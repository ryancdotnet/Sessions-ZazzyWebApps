# Sessions-ZazzyWebApps

In this session, we talked about adding some "Zazz" to your web applications through the power of CSS. And not just standard CSS styles, but with more advanced tools like transitions, animations, and transforms.

In this repository, you will find the Atlas demo project I created to showcase a few cool techniques for web applications.

The Atlas Project showcases:
* Single Page Application design
* ASP.NET MVC
* ASP.NET Web API
* Various CSS styling techniques
* Knockout binding
* and more!

I tried to keep everything as basic as possible to help reduce clutter and business logic confusion. The focus is not on the app itself, but how it works technically.

I would suggest downloading a copy of this repository and opening up the Visual Studio solution and running it. (Ensure that you start both the Atlas.WebApi AND Atlas.WebApp projects together. You can start both projects automatically in VS with the settings on Menu->Debug->Set Startup Projects)

Here are the links to the Liveweave sessions used during the presentation. These help show isolated examples of CSS styling techniques:
* 2 Divs = Radio Buttons - http://liveweave.com/gGk32V
* 2 Divs = Checkboxes - http://liveweave.com/3jtqZA
* 2 Divs = Continuous Progress Bar - http://liveweave.com/kbIS9P
* 2 Divs = Stopwatch Widget - http://liveweave.com/uQYPiM

## Working with the API

Using a REST API client (like Postman - http://www.getpostman.com/), you can call the API to insert and modify some data to see the working processes screen. Here are some sample calls you can make:

### 1. Insert a new Process

  POST /Processes/ HTTP/1.1
  Host: localhost:50989
  Content-Type: application/json
  Cache-Control: no-cache
  Postman-Token: 63890926-534d-7b9a-2f16-bbdef4c1049d

  {
      ProcessId: 1,
      ProcessStatus: "Pending",
      StartDate: null,
      EndDate: null
  }
  
### 2. Update a Process to "Processing"

  POST /Processes/1 HTTP/1.1
  Host: localhost:50989
  Content-Type: application/json
  Cache-Control: no-cache
  Postman-Token: 5883a47f-b81e-c3bc-1238-5f80bf9e1e93
  
  {
      ProcessId: 1,
      ProcessStatus: "Processing",
      StartDate: "2016-03-07 01:00:00 PM",
      EndDate: null
  }
  
### 3. Update a Process to "Complete"

  POST /Processes/1 HTTP/1.1
  Host: localhost:50989
  Content-Type: application/json
  Cache-Control: no-cache
  Postman-Token: 0d3545e1-21eb-4b6a-1018-9d748445d629
  
  {
      ProcessId: 1,
      ProcessStatus: "Complete",
      StartDate: "2016-03-07 01:00:00 PM",
      EndDate: "2016-03-07 01:24:00 PM"
  }
  
### 4. Delete all Processes
  
  DELETE /Processes/ HTTP/1.1
  Host: localhost:50989
  Content-Type: application/json
  Cache-Control: no-cache
  Postman-Token: d20f2a96-b8a3-4af3-5935-b3695744dfc6
