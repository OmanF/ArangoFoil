# ArangoF#oil - a (thin) F# wrapper around ArangoDBNetStandard driver #

[ArangoDB](https://www.arangodb.com/) does have an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C# centric.  
Luckily, it's possible to provide a (thin) F# wrapper around that driver.

## Installation ##

* The easiest way is to get the package from Nuget.  
* Otherwise, build the project then reference the resulting `.dll` file.  
* Last, you can clone the files of this project to your own project (in the order they appear in this project's `.fsproj` file, of course) and reference them in your own project.  

Either way, **don't forget to add and reference this wrapper's core dependency** - `ArangoDBNetStandard` (you get this for free when getting the package from Nuget).  
This wrapper wraps the official driver's version 1.1.1.

## Usage ##

First, use the `bindConnection` function from the `connectionDetails` module to create the connection object holding the relevant connection details. This same function is to be used when needing to switch database(s)/user(s).

The names of each file/namespace correspond to the name of an official driver's API.  
Within each namespace, the names of the **methods** match the corresponding driver API's methods, albeit in *camelCase* syntax (opposed to the official driver's PascalCase).

One caveat, however, is that some of the methods, mostly `POST`, `PUT` and `PATCH`, but not limited to those, require, or take as optional parameters, ArangoDB-specific objects.  
For example, `Document`'s `postDocumentAsync<'T>` method takes an optional parameter, `query` (*among others*), of type `PostDocumentQuery` which is available in `ArangoDBNetStandard.DocumentApi.Models` module.

The (sad) implication of this is that your **application** code will require `open`-ing ArangoDB-specific modules, for example:

```fsharp
// File: MyApp.fs
module MyApp

// Opening and setting up required application data...
// Followed by opening the wrapper's `Document` namespace and its supporting ArangoDB modules.
open Document
open ArangoDBNetStandard.DocumentApi.Models

// Application code...
// Followed by calling the 'postDocumentAsync<'T>' method.
// Notice that since it's a static member, we need to use the dot-notation with a fully-qualified class name.
Document.postDocumentAsync<MyDocumentType>(collectionName, document, PostDocumentQuery(Overwrite = true, Silent = true))
```

You'll need to consult the official driver's documentation to see what type of parameters each of the methods take, and what are each method's applicable properties.

## Some functionality is missing ##

This wrapper provides **most** of the functionality provided by the official driver (which in turn offers **all** the functionality provided by ArangoDB itself).  
I've opted to implement the functionality I've used most when learning to use the DB, leaving out the very remote functionality that's unlikely to ever be required.

If some of the missing functionality **is** required, implementing it should be fairly easy: just follow the official driver's documentation to know what parameters to pass, and the wrapper's code as example how to implement the function.

## Status ##

Despite some of the functionality missing (see previous section), I now consider this wrapper complete, both in features and design.  
Following the Semver protocol, this wrapper is now tagged `1.0.0` and will **not** receive any modification other than bug fixes, unless the official driver's code changes.

## Contributing ##

The usual way of doing FOSS applies:

* Fork the repo.
* Do your thing.
* Send a PR.

I don't have any strict coding standards per-se, other than using the latest *stable* version of `Fantomas`.  
Just mimic the current code style and it'll be fine.

## The name ##

Foil is used to wrap materials.  
By that token, F#oil wraps C# code into code usable from F#. :smile:
