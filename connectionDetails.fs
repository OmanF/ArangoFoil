module ConnectionDetails

open System
open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http

open type Transport.Http.HttpApiTransport

let mutable db =
    new ArangoDBClient(new HttpApiTransport(new Net.Http.HttpClient(), HttpContentType.Json))

let bindConnection (url: string) (dbName: string) (userName: string) (password: string) =
    // Default values for the root user, connecting to the `_system` database on a local instance of ArangoDB, running on Docker, taken from the official image:
    // URL: "http://localhost:8529", Database: "_system", Username: "root", Password: "openSesame"
    db <- new ArangoDBClient(UsingBasicAuth(new Uri(url), dbName, userName, password))
