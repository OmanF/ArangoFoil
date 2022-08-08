# ArangoF#oil - ArangoDB .Net driver (thin) wrapper for F# #

[ArangoDB](https://www.arangodb.com/) has an [official .Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things ".Net", it really means C#.
Luckily, it's easy enough to provide a (thin) wrapper around that driver making it easy to call from F# code.

## Parameterized versus mutable variables ##

The wrapper comes in two "flavors":

* Each call is supplied with **all** the connection parameters.
* The connection parameters are set globally as **mutable** variables that are accessible to all functions.

While the parameterized flavor is more idiomatic, supporting referntial transperancy, it's **extremely** verbose. The global mutable variables seems more correct to the flow of this library: we set the connection details as global variables once, do what we need to setup the ArangoDB, then we will set the details again, thanks to their mutablity, and act on the actual database and collections. If, later, we need, for some reason, to switch database/collection, we can!

## Usage ##

The easiest way to use this library is to copy and/or install the code and its dependencies, i.e. `ArangoDBNetStandard`, as files in your own projects and call it like any other project's file. Otherwise, just build the package and reference the resulting ".dll" file.

## The name? ##

(Tin)foil can be used to wrap materials. F#oil wraps .Net materials into something usable by F#. :smile:
