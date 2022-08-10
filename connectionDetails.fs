module ConnectionDetails

open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http
open System

// Default values: root user on the `_system` database, running on a local Docker-hosted instance
let mutable url = "http://localhost:8529"
let mutable username = "root"
let mutable password = "openSesame"
let mutable dbName = "_system"

let mutable dbTransport =
    HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

let mutable db = new ArangoDBClient(dbTransport)

let rebindConnection () =
    dbTransport <- HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)
    db <- new ArangoDBClient(dbTransport)
