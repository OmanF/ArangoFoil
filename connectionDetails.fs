module ConnectionDetails

open System
open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http

open type Transport.Http.HttpApiTransport

let mutable db =
    new ArangoDBClient(new HttpApiTransport(new Net.Http.HttpClient(), HttpContentType.Json))

/// <summary>
/// Create the connection to the specified ArangoDB database, using specified user's credentials.
/// </summary>
/// <param name="url">The URL of the required ArangoDB instance.</param>
/// <param name="dbName">The name of the database with the ArangoDB instance to connect to.</param>
/// <param name="userName">The username of the user logging in to the ArangoDB instance. Only useful when the connection schema is `basic`.</param>
/// <param name="password">The password of the user logging in to the ArangoDB instance. Only useful when the connection schema is `basic`.</param>
let bindConnection (url: string) (dbName: string) (userName: string) (password: string) =
    // Default values for the root user, connecting to the `_system` database on a local instance of ArangoDB, running on Docker, taken from the official image:
    // URL: "http://localhost:8529", Database: "_system", Username: "root", Password: "openSesame"
    db <- new ArangoDBClient(UsingBasicAuth(new Uri(url), dbName, userName, password))
