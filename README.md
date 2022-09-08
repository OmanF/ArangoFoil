# ArangoF#oil - a (thin) F# wrapper around ArangoDBNetStandard driver #

[ArangoDB](https://www.arangodb.com/) *has* an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C#-centric.  
Luckily, it's easy enough to provide a (thin) wrapper around that driver making it easy to call from F# code.

## Installation ##

The easiest way is to build the project then reference the resulting '.dll' file.  
Another way is to clone the files of this project to your own project (in the order they appear in this project's '.fsproj' file, of course) and reference them in your own project's '.fsproj' file.

Either way, don't forget to import this wrapper's core dependency, i.e., `ArangoDBNetStandard`, either via `dotnet` CLI or using `Paket`.  
(As a side note, this wrapper wraps the official driver's version 1.1.1, so make sure to import this version for compatibility).

It is unlikely this will ever become a Nuget package.

## Usage ##

// TODO: Write something here!

## Some functionality is missing ##

This wrapper provides **most** of the functionality provided by the official driver (which in turn offers **all** the functionality provided by ArangoDB itself).  
I've opted to implement the functionality I've used most when learning to use the DB, leaving out the very remote functionality that's unlikely to ever be required (at least not programatically).

If some of the missing functionality **is** required, implementing it should be fairly easy: just follow the official driver's documentation to know what parameters to pass, and the wrapper's code as example how to implement the function.

## 1.0.0? ##

I agree that tagging this wrapper with a '1.x.y' tag was a bit over the top, but following SemVer protocol, this tag is meant to convey the fact that I now consider this wrapper complete, both in features and design (both of which changed a lot during the WIP phase).

## Contributing ##

The general way of doing FOSS applies here too:

* Fork the repo.
* Do your thing.
* Send a PR.

I don't have any strict coding standards, per-se. Just look at the current code and follow suit and it'll be fine.  
(Do use `Fantomas` though. I love that tool, it's the best!)

## The name? ##

(Tin)foil can be used to wrap materials. F#oil wraps .Net materials into something usable by F#. :smile:
