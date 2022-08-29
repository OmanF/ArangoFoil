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

let postDatabaseAsync
    newDatabaseName
    (newDatabaseUsersList: (string * string * bool * Dictionary<string, obj> option) list)
    =
    let databaseUsers =
        newDatabaseUsersList
        |> List.collect (fun newUser ->
            match newUser with
            | userName, password, active, Some extra ->
                [ DatabaseUser(Username = userName, Passwd = password, Active = active, Extra = extra) ]
            | userName, password, active, None ->
                [ DatabaseUser(Username = userName, Passwd = password, Active = active) ])
        |> Array.ofList

    db
        .Database
        .PostDatabaseAsync(PostDatabaseBody(Name = newDatabaseName, Users = databaseUsers))
        .GetAwaiter()
        .GetResult()
