# ArangoF#oil - ArangoDB .Net driver (thin) wrapper for F# #

[ArangoDB](https://www.arangodb.com/) has an [official .Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things ".Net", it really means C#.
Luckily, it's easy enough to provide a (thin) wrapper around that driver making it easy to call from F# code.

## Mutable variables usage ##

The official driver recommends having only a single `HttpApiTransport` (and therefore `ArangoDBClient`) for the entire life-cycle of the entire application. That means refraining from using the keyword `use` with them, by which they will be disposed (both implementing the `IDisposable` interface) once out of scope.

This behavior lends itself nicely to a flow based on **mutable, global** variables holding the database connection details: the connection string (URL), username, password, and the actual database to connect to.

The flow then goes along the lines of:

* Initialize the variables with some value, likely representing the root user's credentials and the `_system` database (which is the only usecase for creating new databases!)
* Create said databases.
* Set the global variables to the new database's details.
* Do work on the database.
* If the need for another database arises, switching back to the `_system` database, and then to any other database later is as easy as setting a mutable global variable.

Alternatively, just call the database creating function with the variables verbatim, e.g. `dbCreate "http://localhost:8529" "rootUser" "rootPass" "_system"`, switching the variables each time a change is required. I just like the mutable variable approach better.

## Usage ##

The easiest way to use this library is to copy and/or install the code and its dependencies, i.e. `ArangoDBNetStandard`, as files in your own projects and call it like any other project's file. Otherwise, just build the package and reference the resulting ".dll" file.

## The name? ##

(Tin)foil can be used to wrap materials. F#oil wraps .Net materials into something usable by F#. :smile:
