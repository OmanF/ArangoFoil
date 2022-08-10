module Databases

open ArangoDBNetStandard
open ArangoDBNetStandard.DatabaseApi.Models
open System
open ConnectionDetails

let getCurrentDatabaseInfoAsync () =
    try
        Ok
        <| db
            .Database
            .GetCurrentDatabaseInfoAsync()
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let getDatabasesAsync () =
    try
        Ok
        <| db
            .Database
            .GetDatabasesAsync()
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let getUserDatabaseAsync () =
    try
        Ok
        <| db
            .Database
            .GetUserDatabasesAsync()
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let createDatabaseAsync newDatabaseName newDatabaseUsers =
    try
        let body = new PostDatabaseBody(Name = newDatabaseName, Users = newDatabaseUsers)

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


let deleteDatabaseAsync dbToDelete =
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
