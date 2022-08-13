module Databases

open ArangoDBNetStandard.DatabaseApi.Models
open ConnectionDetails

let getCurrentDatabaseInfoAsync () =
    db
        .Database
        .GetCurrentDatabaseInfoAsync()
        .GetAwaiter()
        .GetResult()

let getDatabasesAsync () =
    db
        .Database
        .GetDatabasesAsync()
        .GetAwaiter()
        .GetResult()

let getUserDatabaseAsync () =
    db
        .Database
        .GetUserDatabasesAsync()
        .GetAwaiter()
        .GetResult()

let createDatabaseAsync newDatabaseName newDatabaseUsers =
    let body = new PostDatabaseBody(Name = newDatabaseName, Users = newDatabaseUsers)

    db
        .Database
        .PostDatabaseAsync(body)
        .GetAwaiter()
        .GetResult()

let deleteDatabaseAsync dbToDelete =
    db
        .Database
        .DeleteDatabaseAsync(dbToDelete)
        .GetAwaiter()
        .GetResult()
