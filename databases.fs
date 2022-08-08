module Databases

open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http
open ArangoDBNetStandard.DatabaseApi.Models
open System

let mutable url = "http://localhost:8529"
let mutable username = "root"
let mutable password = "openSesame"
let mutable dbName = "_system"

let getCurrentDBInfo () =
    try
        use transport =
            HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

        use db = new ArangoDBClient(transport)

        let response =
            db
                .Database
                .GetCurrentDatabaseInfoAsync()
                .GetAwaiter()
                .GetResult()

        Ok response
    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let getAllDBs () =
    try
        use transport =
            HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

        use db = new ArangoDBClient(transport)

        let response =
            db
                .Database
                .GetDatabasesAsync()
                .GetAwaiter()
                .GetResult()

        Ok response
    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let setupDBUserCreds username password active =
    new DatabaseUser(Username = username, Passwd = password, Active = active)

let setupNewDB dbName users =
    new PostDatabaseBody(Name = dbName, Users = users)

let createDB (newDBName: string) (newDBUsers: seq<DatabaseUser>) =
    try
        use transport =
            HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

        use db = new ArangoDBClient(transport)
        let body = new PostDatabaseBody(Name = newDBName, Users = newDBUsers)

        Ok
        <| db
            .Database
            .PostDatabaseAsync(body)
            .GetAwaiter()
            .GetResult()
    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex


let deleteDB (dbToDelete: string) =
    try
        use transport =
            HttpApiTransport.UsingBasicAuth(new Uri(url), dbName, username, password)

        use db = new ArangoDBClient(transport)

        Ok
        <| db
            .Database
            .DeleteDatabaseAsync(dbToDelete)
            .GetAwaiter()
            .GetResult()
    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex
