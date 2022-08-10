module Databases

open ArangoDBNetStandard
open ArangoDBNetStandard.DatabaseApi.Models
open System
open ConnectionDetails

let getCurrentDBInfo () =
    try
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
