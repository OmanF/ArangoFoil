module Users

open ArangoDBNetStandard
open ArangoDBNetStandard.UserApi.Models
open System
open ConnectionDetails

type AccessLevel =
    | NotAuthorized
    | ReadOnly
    | ReadWrite

let accessLevelClassifierHelperFunction accessLevel =
    accessLevel
    |> function
        | NotAuthorized -> "none"
        | ReadOnly -> "ro"
        | ReadWrite -> "rw"

let getUsersAsync () =
    try
        Ok
        <| db.User.GetUsersAsync().GetAwaiter().GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let getUserAsync userName =
    try
        Ok
        <| db
            .User
            .GetUserAsync(userName)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let createUserAsync userName password active =
    let isActive = Option.defaultValue true active

    try
        Ok
        <| db
            .User
            .PostUserAsync(PostUserBody(User = userName, Passwd = password, Active = isActive))
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let patchUserAsync userName password active =
    let isActive = Option.defaultValue true active

    try
        Ok
        <| db
            .User
            .PatchUserAsync(userName, PatchUserBody(Passwd = password, Active = isActive))
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let replaceUserAsync userName password active =
    let isActive = Option.defaultValue true active

    try
        Ok
        <| db
            .User
            .PutUserAsync(userName, PutUserBody(Passwd = password, Active = isActive))
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let deleteUserAsync userName =
    try
        Ok
        <| db
            .User
            .DeleteUserAsync(userName)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let grantDatabaseAccessAsync userName database accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    try
        Ok
        <| db
            .User
            .PutDatabaseAccessLevelAsync(userName, database, PutAccessLevelBody(Grant = access))
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let grantCollectionAccessAsync userName database collection accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    try
        Ok
        <| db
            .User
            .PutCollectionAccessLevelAsync(
                userName,
                database,
                collection,
                PutAccessLevelBody(Grant = access)
            )
            .GetAwaiter()
            .GetResult

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let removeDatabaseAccessAsync userName database =
    try
        Ok
        <| db
            .User
            .DeleteDatabaseAccessLevelAsync(userName, database)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let removeCollectionAccessAsync userName database collection =
    try
        Ok
        <| db
            .User
            .DeleteCollectionAccessLevelAsync(
                userName,
                database,
                collection
            )
            .GetAwaiter()
            .GetResult

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex
