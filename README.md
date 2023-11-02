# ECommerceApplication

Coding Steps I did to create the application:

Part 1:

1. Create empty solution
2. Create folder structure
3. Create first service which is nothing but web api project inside Services folder
4. Create models and models DTO
5. Install Automapper, Automapper DI, EFCore, EFCore SQL, EFCore tools(which helps in migration)
6. Create AppDbContext file and create DbSet method.
7. Do the entry in Program.cs
8. Add related SQL connection string to json file and program.cs service option.
9. Add-migration anyName
10. Update Database.
11. Do seeding (to fill table in database with initial values)
12. For seeding add OnModelCreation method in AppDbContext class and do changes.
13. Add apply migration logic to program.cs to call update database automatically each time when application runs.
14. Add Controller to perform CRUD operation
15. Create ResponseDto to maintain same level of response across all the calls.
16. Now, Configure AutoMapper. Add Mapping class and create necessary Mapping.
17. Complete remaining CRUD operations and done.

Part 2:

1. Create new web mvc project inside Frontend folder
2. Create Response DTO to capture result coming from api.
3. Create Request DTO which will have things like apiType, URL, data, token etc.
4. Create base service to interact with the api. It should have method like Send.
5. In send method above we will add or core logic of using HttpClientFactory.
6. Create client/request/response , add switch case depending on the apiType sent and call the API.
7. Make sure to configure the url for api in setting files.
8. Now create ICouponService and CouponService to perform all crud operations.
9. Ultimately call will be navigated via Base service only.
10. Register all the services in Program.cs and implement it accordingly.
11. Once done, it's time for some UI.
12. Go to Bootswatch and select your fav theme.(Download bootstrap.css for the same)
13. Change the basic styling and add dropdown logic(navbar)
14. Start Creating coupon controller (MVC controller)
