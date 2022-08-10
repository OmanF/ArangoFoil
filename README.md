# ArangoF#oil - a (thin) F# wrapper around `ArangoDBNetStandard` driver #

[ArangoDB](https://www.arangodb.com/) *has* an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C#-centric.  
Luckily, it's easy enough to provide a (thin) wrapper around that driver making it easy to call from F# code.

## Mutable variables ##

The official driver recommends having only a single `HttpApiTransport` for the entire life-cycle of the application.  
(See the "Remarks" section [here](https://arangodb-community.github.io/arangodb-net-standard/v1-1-0/html/1a9b4516-9078-d867-e5f5-6a99e3f31ee4.htm)).

This behavior lends itself nicely to a flow based on **mutable, global** variables holding the database connection details: the connection string (URL), username, password, and the actual database to connect to.

The flow then proceeds as following:

* Initialize the variables with the root user's credentials and the `_system` database.
* Create new database(s).
* Create new user(s) and give them required permissions.
* Rebind the connection variables to the new database/user's details.
* Continue working on the new database using the non-root user.
* (If another new database/user is required, repeat flow as necessary).

## Usage ##

The easiest way to use this library is to copy the code files into your own projects, not forgetting to reference them in the `.fsproj` file, nor to install their dependency, i.e., the `DBNetStandard` nuget, and treat them like any other project's file/modules.

Otherwise, just build the package and reference the resulting `.dll` file.

## Some functionality is missing? ##

The official driver has an [implementation](https://github.com/ArangoDB-Community/arangodb-net-standard/tree/master/arangodb-net-standard) for **most** of the APIs listed on [ArangoDB's HTTP page](https://www.arangodb.com/docs/stable/http/).

Once an `ArangoDBClient` is created it has access to all those [APIs](https://arangodb-community.github.io/arangodb-net-standard/v1-1-0/html/ba0f435e-0803-bafd-7a3d-9963d8a82ad8.htm), manifested as the object's properties, via the usual "dot-into" mechanism (e.g. `dbClient.User`).

Do note that some code "gymnastics" is required, especially when instantiating a class, to allow F# to call the driver's C# code.

(On that note, PRs are welcome, thank you very much.)

## The name? ##

(Tin)foil can be used to wrap materials. F#oil wraps .Net materials into something usable by F#. :smile:
