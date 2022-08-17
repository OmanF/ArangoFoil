# ArangoF#oil - a (thin) F# wrapper around `ArangoDBNetStandard` driver #

[ArangoDB](https://www.arangodb.com/) *has* an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C#-centric.  
Luckily, it's easy enough to provide a (thin) wrapper around that driver making it easy to call from F# code.

## Mutable variables ##

The official driver recommends having only a single `HttpApiTransport` for the entire life-cycle of the application.  
(See the "Remarks" section [here](https://arangodb-community.github.io/arangodb-net-standard/v1-1-0/html/1a9b4516-9078-d867-e5f5-6a99e3f31ee4.htm)).

This behavior lends itself nicely to a flow based on **mutable, global** variables holding the database connection details: the connection string (URL), username, password, and the actual database to connect to.

The flow then proceeds as following:

* Initial `HttpApiTransport` object is created blank!
* Bind the connection using the required user and database details.
* (If needed) create new database(s) and/or new user(s), not forgetting to give the new users correct permissions for the database(s)/collection(s) as needed.
* (If needed) rebind the connection with the new database/user's details.
* Repeat the flow as needed.

## Usage ##

The easiest way to use this library is to copy the code files into your own projects, not forgetting to reference them in the `.fsproj` file, nor to install their dependency, i.e., the `ArangoDBNetStandard` nuget, and treat them like any other project's file/modules.

Otherwise, just build the package and reference the resulting `.dll` file (again, not forgetting to install the `ArangoDBNetStandard` nuget dependency).

Some of the functions, mostly those that create or update, entities (databases, collections, documents, users, etc.) require creating, and passing, instances of the corresponding `Model` class. This in turn means the application code calling those functions will need to `open` the `Model`(s).  
While this forcefully injects the driver's code into the application code, this is an intentional decision as I prefer to have the functions as robust, and conforming to both the C# driver, and the HTTP underlying the driver, specifications over a simpler, incomplete, function.  
In the same vein, none of the functions support the `<API name>HeaderProperties` that some of the C#'s driver's functions offer since these instances don't manipulate the request in any way, like the options may, and the information returned by those headers is mostly useful only in debug (which would be better suited over the UI and/or `arangosh`).

## Some functionality is missing? ##

The official driver has an [implementation](https://github.com/ArangoDB-Community/arangodb-net-standard/tree/master/arangodb-net-standard) for **most** of the APIs listed on [ArangoDB's HTTP page](https://www.arangodb.com/docs/stable/http/).

Once an `ArangoDBClient` is created it has access to all those [APIs](https://arangodb-community.github.io/arangodb-net-standard/v1-1-0/html/ba0f435e-0803-bafd-7a3d-9963d8a82ad8.htm), manifested as the object's properties, via the usual "dot-into" mechanism (e.g. `dbClient.User`).

Do note that some code "gymnastics" is required, especially when instantiating a class, to allow F# to call the driver's C# code.

(On that note, PRs are welcome, thank you very much.)

## The name? ##

(Tin)foil can be used to wrap materials. F#oil wraps .Net materials into something usable by F#. :smile:
