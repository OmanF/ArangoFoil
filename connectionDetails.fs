module ConnectionDetails

open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http
open System

let mutable url = "http://localhost:8529"
let mutable username = "root"
let mutable password = "openSesame"
let mutable dbName = "_system"

let dbTransport =
    HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

let db = new ArangoDBClient(dbTransport)
