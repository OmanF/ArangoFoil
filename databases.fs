module Databases

open ArangoDBNetStandard.DatabaseApi.Models
open ConnectionDetails
open System.Collections.Generic

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

let postDatabaseAsync newDatabaseName (newDatabaseUsersList: (string * string * bool * Dictionary<string, obj>) list) =
    let databaseUsers =
        newDatabaseUsersList
        |> List.toArray
        |> Array.collect (fun user ->
            let userName, password, active, extra = user
            [| DatabaseUser(Username = userName, Passwd = password, Active = active, Extra = extra) |])


    db
        .Database
        .PostDatabaseAsync(PostDatabaseBody(Name = newDatabaseName, Users = databaseUsers))
        .GetAwaiter()
        .GetResult()
