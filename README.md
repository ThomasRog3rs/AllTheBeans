
# My soloution to Scenario 2 - (AllTheBeans)
[Tech Test 1 04.03.25.pdf](https://github.com/user-attachments/files/20804834/Tech.Test.1.04.03.25.pdf)

## Assumptions made
- Authentication and Authirzation was not required for PUT and POST endpoints.
- EntityFramework Code First is an acceptable approach to creating the schema
- Unit testing alone is acceptable, end-end and stress testing are out of scope

## Features
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
In the root directory of the project run:
```dotnet test```
Not 100% test coverage, a focus on buisness logic and using mochable dependencies

## Known Issues / Edge cases / Limitations
1. When the bean of the Day is deleted, the GET bean-of-the-day endpoint returns 404. A useful feature would be to pick a new bean if one is not found as on the UI it is required.
2. Error handling could be improved:
    - DB operations could fail, adding try-catch for these would be more robust
3. Use of Logging for errors could be improved
4. Anyone with access to the API can make modifications without Authentication, Authirization or even rate-limiting
    - Since this is not a production application, I did feel this was out of scope
  
## Thanks
Thank you for taking the time to review this Tech Test and for the oppertunity to interview at Tombola.
I am looking forward to hearing your feedback.
