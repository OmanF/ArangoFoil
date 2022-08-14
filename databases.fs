module Databases

open ArangoDBNetStandard.DatabaseApi.Models
open ConnectionDetails

let deleteDatabaseAsync dbToDelete =
    db
        .Database
        .DeleteDatabaseAsync(dbToDelete)
        .GetAwaiter()
        .GetResult()

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

let createDatabaseAsync (newDatabaseMetadata: PostDatabaseBody) =
    db
        .Database
        .PostDatabaseAsync(newDatabaseMetadata)
        .GetAwaiter()
        .GetResult()
