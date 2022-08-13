module ConnectionDetails

open System
open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http

open type Transport.Http.HttpApiTransport

let mutable dbTransport =
    new HttpApiTransport(new Net.Http.HttpClient(), HttpContentType.Json)

let mutable db = new ArangoDBClient(dbTransport)

let bindConnection (url: string) (dbName: string) (userName: string) (password: string) =
    // Default values for the root user, connecting to the `_system` database on a local instance of ArangoDB, running on Docker, taken from the official image:
    // URL: "http://localhost:8529", Database: "_system", Username: "root", Password: "openSesame"
    dbTransport <- UsingBasicAuth(new Uri(url), dbName, userName, password)
    db <- new ArangoDBClient(dbTransport)
