## Summarization of specs:
Develop an application which **register parkings** and **close the spaceport when it's full** (and open when there is room, and only for spaceships which fits in). **All parkings should be registered in a database**, which is created using Entity Framework Core and code first. All queries to the database should be done using Entity Frameworks fluent API. The new twist to this is that **all the logic should be contained within a REST API**, and only this API should be able to access the database.

As the logic will now be collected in one web API **should it now be a multi-tenant application**, which means that the API should have support for multiple spaceports.

The travellers only use starships which have been part of a Starwars movie (see the endpoint /starships). They should **be able to select their starship** on arrival in the application. The travlers should **identify them self when arriving**, be able to **pay before they can leave the parking lot** and **get an invoice in the end**.

There is two kind of users in this application.

The vistors, which can:

* Register a parking
* Get information on current parking
* End parking and "pay"
* Get information on all previous parkings

The administrator, which can:
* Add new spaceports to the system

It should **be possible to perform all operations through requests to the API**, if you would like to develop an interface to this application should it be a console application which makes requests to the API.

The application should **save the parkings, payments etc to the a database defined using Entity Framework och code first**.

**Along with all requests in the system should be passed a HTTP header with an API key**, it could look like:
*GET /spaceports HTTP/1.1
apikey: secret1234*

**Evaluate this key with a custom middleware which reads the apikey-header and evaluates if the key is approved**, if not should the request be rejected.

It's not a requirement to have different keys for different users, nor is it a requirement that the key should provide access different functionality. We trust our users, so that do not missuse the system.

**The database used in the project should be defined in a docker-compose file**, so that all developers can use the same connection string in the project.

