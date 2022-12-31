# ArangoF#oil - a (thin) F# wrapper around ArangoDBNetStandard driver #

[ArangoDB](https://www.arangodb.com/) does have an official [.Net driver](https://github.com/ArangoDB-Community/arangodb-net-standard), however as most things .Net, it is C# centric.  
Luckily, it's possible to provide a (thin) F# wrapper around that driver.

## Installation ##

* The easiest way is to get the package from Nuget.  
* Otherwise, build the project then reference the resulting `.dll` file.  
* Last, you can clone the files of this project to your own project (in the order they appear in this project's `.fsproj` file, of course) and reference them in your own project.  

This wrapper wraps the official driver's version 1.3.0.

## Usage ##

***TODO*: Fill in here, in as much detail as I'm able to write without getting bored to death. I hate documenting stuff!**

## Some functionality is missing ##

This wrapper provides **most** of the functionality provided by the official driver (which in turn offers **all** the functionality provided by ArangoDB itself).  
I've opted to implement the functionality I've used most when learning to use the DB, leaving out the very remote functionality that's unlikely to ever be required.

If some of the missing functionality **is** required, implementing it should be fairly easy: just follow the official driver's documentation to know what parameters to pass, and the wrapper's code as example how to implement the function.  
(Of course, PRs are welcome!)

## Status ##

When I first released this package as Nuget it was, for various reasons, all of which are my fault, lacking and unfunctional (except for a *very* specific workflow that was useful to me).  
Since I was the only user of the package, and using it in the specific way that allowed it to work correctly, I didn't even know how badly broken the package was until a couple of weeks ago I tried using it as part of a side-project I'm working on where it failed. Miserably. As was expected, to be honest.

This new release I'm dog fooding my own code as well as trying to get as many of the functions tested (either on the REPL or in above said side-project).  
While I **still** can't guaruntee this version is more stable, and/or useful, than the previous release, I **can** say that "so far - so good".

This version is `2.y.z` since, according to the SemVer protocol of version numbering, it poses a **huge, and breaking** refactoring of the previous code.  
It's literally an entire different code, excpet for the ArangoDB API calls.

I consider this release to be stable, useable (again, mostly by myself), and correct.

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
