[Tech Test 1 04.03.25.pdf](https://github.com/user-attachments/files/20804834/Tech.Test.1.04.03.25.pdf)
# How to run both projects with Docker
- prerequisite: Docker installed
- After cloning the repo, run ```docker-compose up --build```
- For frontend: [http://localhost:8080/](http://localhost:8080/)
- For backend: [http://localhost:5001/swagger/index.html](http://localhost:5001/swagger/index.html)
# My soloution to Scenario 2 - (AllTheBeans API)

## Assumptions made
- Authentication and Authirzation was not required for PUT and POST endpoints.
- EntityFramework Code First is an acceptable approach to creating the schema
- Unit testing alone is acceptable, end-end and stress testing are out of scope

## Features
1. Design and implement a relational database schema to store the bean details from the JSON file provided. ✅
2. Create RESTful APIs to handle CRUD operations for coffee beans and Fetch the "Bean of the Day". ✅
3. Implement business logic to ensure:
    - Each day, a new "Bean of the Day" is selected randomly from the available beans. ✅
    - The selected bean cannot be the same as the previous day. ✅
4. Implement a database search feature to show products available ✅

- Seeds the database from the provided json file and picks the first bean of the day
- All CRUD operations implimented for coffees
- Validation implimented with DataAnnotations
- Works with Docker
- Unit Tests for buisness logic

## Techologies Used and Why
1. .NET 8
    - I chose this because its the latest LTS version of .NET 
    - (and because .NET 9 gave me some greif in docker)
2. Controllers rather than MinimaAPI
    - A small project like this, I would usually prefer MinimalAPIs as full controllers are not really needed
    - I chose controllers because I thought it would be more, stylisticly, like what you use at Tombola in .NET Framework
3. SQLite
    - A full fat instance of postgres or MSSQL was not required for such a small project
    - A simple single file that can be in the project and created on the fly on startup
    - Can be persited when it is no logner running unlike an in-memory database
4. EntityFramework (Code First)
    - I knew the code first approach would handle migrations well because the data is not complex
    - I did consider Dapper to show my SQL knowledge, but since I also wrote the seeding logic it made sense to use Code First approach with EntityFramework (because the data is generated from code)
5. SwaggerUI
    - .NET API projects no longer come with swagger and it is popular to choose a more modern client for your swaggerDco
    - However, Swagger is the classic choice, it's just what I am used to and probably what you are most used to
    - I did consider Scalar
6. Docker
    - I know Containerization is used at Tombola
7. xUnit
    - An easy to use modern testing framework
  
## Testing
In the ```/API``` directory run:
```dotnet test```
Not 100% test coverage, a focus on buisness logic and using mochable dependencies

## Known Issues / Edge cases / Limitations
1. When the bean of the Day is deleted, the GET bean-of-the-day endpoint returns 404. A useful feature would be to pick a new bean if one is not found as on the UI it is required.
3. Error handling could be improved:
    - DB operations could fail, adding try-catch for these would be more robust
4. Use of Logging for errors could be improved
5. Anyone with access to the API can make modifications without Authentication, Authirization or even rate-limiting
    - Since this is not a production application, I did feel this was out of scope
6. If the application was to scale the pagination on the get endpoint would be required
  

# My soloution to Scenario 1 - (AllTheBeans UI)
I decided to do a combination of Scenario 1 and 2 because the Job role is for a Full-Stack developer so I wanted to display by knowledge of creating a full-stack application 

## Assumptions made
- Any libary of choice and tools could be used
- Use of LLMs is permissable for css/tailwindcss styling

## Features
1. Create a responsive layout using modern UI frameworks or libraries. ✅
2. Using the attached JSON file implement components to display:
    - List of available coffee beans. ✅ (Fetch the API)
    - Detailed view of a selected coffee bean. ❌
    - "Bean of the Day" feature which is interactable for more information ✅ (Not interactable)
3. Create an order form for customers to purchase coffee beans. ❌
4. Implement a search feature to filter coffee beans by the available data. ✅ (Client side filter, no search but the API does have a search endpoint)

## Techologies Used and Why
1. Vue.js
    - I chose this because vue.js is listed on the Job Spec
    - It is the UI libary that I am most comftable with
    - Since this is a small applications other valid options could have been:
        - Alpine.js
        - JQuery
2. TypeScript
    - Defining types, in my oppinion, often makes code more readable and easier to debug
    - Helps identify errors early that otherwise could make it to prod
    - Allows for full-stack type saftey which helps ensure propper communication between the backend and frontend
3. [openapi-generator-cli](https://www.npmjs.com/package/@openapitools/openapi-generator-cli)
    - Allows you to generate ts types from a swagger doc
    - Generates a client for interfacing with the API, good DX
4. Tailwindcss
    - Easy to use css util libary (much easier than raw css and more flexable than bootstrap)
    - LLMs are quite good with tailwindcss
    - Only ships the css actually used. It does not force the client to receive a bloated css file, most of which is not even used
5. Pinia
    - The reccomend state management libary for Vue
    - Allows for glbal shared state, reducing the complexity of sharing state between components
  
## Testing
I did plan to use playwright to perform some UI testing but I did not have time to do this.

## Known Issues / Edge cases / Limitations
1. Loads in all beans at once, if the API sends a lot of beans the page would become slower and it would be a bad UX scrolling through so many beans
2. Filter logic does not follow the Open/Close princable in SOLID

# Thanks
Thank you for taking the time to review this Tech Test and for the oppertunity to interview at Tombola.
I am looking forward to hearing your feedback.
