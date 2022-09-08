module Users

open ArangoDBNetStandard.UserApi.Models
open ConnectionDetails
open System.Collections.Generic
open System

type AccessLevel =
    | NotAuthorized
    | ReadOnly
    | ReadWrite

type UnofficialPatchUserBody =
    { Passwd: string
      Active: Nullable<bool>
      Extra: Dictionary<string, obj> option }

type UnofficialPostUserBody =
    { User: string
      Passwd: string
      Active: Nullable<bool>
      Extra: Dictionary<string, obj> option }

let accessLevelClassifierHelperFunction accessLevel =
    accessLevel
    |> function
        | NotAuthorized -> "none"
        | ReadOnly -> "ro"
        | ReadWrite -> "rw"

let deleteCollectionAccessAsync username dbName collectionName =
    db
        .User
        .DeleteCollectionAccessLevelAsync(username, dbName, collectionName)
        .GetAwaiter()
        .GetResult()

let deleteDatabaseAccessAsync username dbName =
    db
        .User
        .DeleteDatabaseAccessLevelAsync(username, dbName)
        .GetAwaiter()
        .GetResult()

let deleteUserAsync username =
    db
        .User
        .DeleteUserAsync(username)
        .GetAwaiter()
        .GetResult()

let getUserAsync username =
    db
        .User
        .GetUserAsync(username)
        .GetAwaiter()
        .GetResult()

let getUsersAsync () =
    db.User.GetUsersAsync().GetAwaiter().GetResult()

let patchUserAsync username (body: UnofficialPatchUserBody) =
    let patchedUser =
        PatchUserBody(Passwd = body.Passwd, Active = body.Active, Extra = Option.defaultValue null body.Extra)

    db
        .User
        .PatchUserAsync(username, patchedUser)
        .GetAwaiter()
        .GetResult()

let postUserAsync (body: UnofficialPostUserBody) =
    let newUser =
        PostUserBody(
            User = body.User,
            Passwd = body.Passwd,
            Active = body.Active,
            Extra = Option.defaultValue null body.Extra
        )

    db
        .User
        .PostUserAsync(newUser)
        .GetAwaiter()
        .GetResult()

let putCollectionAccessAsync username dbName collectionName accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutCollectionAccessLevelAsync(username, dbName, collectionName, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

let putDatabaseAccessAsync username dbName accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutDatabaseAccessLevelAsync(username, dbName, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

let putUserAsync username (body: UnofficialPatchUserBody) =
    let replacedUser =
        PutUserBody(Passwd = body.Passwd, Active = body.Active, Extra = Option.defaultValue null body.Extra)

    db
        .User
        .PutUserAsync(username, replacedUser)
        .GetAwaiter()
        .GetResult()
