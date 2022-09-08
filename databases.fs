module Databases

open ArangoDBNetStandard.DatabaseApi.Models
open ConnectionDetails
open System.Collections.Generic
open System

type UnofficialDatabaseUser =
    { Active: Nullable<bool>
      Extra: Dictionary<string, obj> option
      Passwd: string
      Username: string }

type PostDatabase =
    { Name: string
      Users: seq<UnofficialDatabaseUser> }

let deleteDatabaseAsync databaseName =
    db
        .Database
        .DeleteDatabaseAsync(databaseName)
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

let getUserDatabasesAsync () =
    db
        .Database
        .GetUserDatabasesAsync()
        .GetAwaiter()
        .GetResult()

let postDatabaseAsync (request: PostDatabase) =
    let dbUsers =
        request.Users
        |> Seq.collect (fun dbUser ->
            [| DatabaseUser(
                   Username = dbUser.Username,
                   Active = dbUser.Active,
                   Passwd = dbUser.Passwd,
                   Extra = Option.defaultValue null dbUser.Extra
               ) |])

    db
        .Database
        .PostDatabaseAsync(PostDatabaseBody(Name = request.Name, Users = dbUsers))
        .GetAwaiter()
        .GetResult()
