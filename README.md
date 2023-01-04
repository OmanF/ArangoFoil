# ArangoF#oil - a (thin) F# wrapper around ArangoDBNetStandard driver #

[ArangoDB](https://www.arangodb.com/) does have an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C# centric.  
Luckily, it's possible to provide a (thin) F# wrapper around that driver.

## Installation ##

The easiest way is to get the package from Nuget.

At time of publishing, the wrapper depends on the official driver's version `1.3.0`.

## Usage ##

First instansiate `ArangoFoilClient`.  
Once created, call the `bindBasicAuthConnection` method with appropriate arguments to bind the client object to a specific server/database/user combo.  
(A version supporting JWT authentication isn't currently available).

___Note___:  
ArangoDB only introduced `healthcheck` since version `3.10.0`, so when passing the `runHealthCheck` argument, only pass `true` if you know for a fact your instance of ArangoDB server supports it, or the healthcheck __will__ fail and abort the entire script.  
(If unsure, just pass `false` which side steps the entire check, optimistically assuming the server and database are up).

Once a connection has successfully been setup you can "dot into" the client object to see all available methods.

Names of methods correspond to the official driver's names with differences being using camel case instead of C#'s Pascal case and dropping the `...Async` that terminates all the official driver's methods' names, so, for example, the wrapper's `postDocument` will show up as `PostDocumentAsync` on the official documentation.  
A _minor_ note: due to F# strong type system, stronger than C#'s, some methods that don't take a generic parameter in the official driver (e.g. `PostCursorAsync`) require such a type in the wrapper version, so, continuing the example, the corresponding method in the wrapper is `postCursor<'T>`.

Most method names are self-describing however consulting the official driver's documentation is __strongly advised__.  

___Cavaet___:  
Some of the methods take, either as optional, or mandatory, arguments, objects that are unique to ArangoDB driver: for example `postCursor` takes, as mandatory argument, an object of type `PostCursorBody`.

As a result, your __application__ code needs to be able to instansiate those objects.

For example, code using the `postCursor` method might look like:

```fsharp
module TestPostCursor

open ArangoDBNetStandard.CursorApi.Models // The module containing `PostCursorBody` type
...

afc.postCursor(PostCursorBody(Query = "SELECT itr IN iterators RETURN itr"))
...
```

## Status ##

While I make __zero promises__ about the quality or functionality of this package I consider the release to be stable and correct.

## Contributing ##

As per FOSS norms:

* Fork the repo.
* Do your thing.
* Send a PR.

Only coding standard I ask is using the _latest stable_ `Fantomas` with _default settings_ to format the code.

## The name ##

Foil is used to wrap materials.  
By that token, F#oil wraps C# code into code usable from F#. :smile:
