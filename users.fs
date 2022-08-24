module Users

open ArangoDBNetStandard.UserApi.Models
open ConnectionDetails
open System.Collections.Generic

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

let deleteCollectionAccessAsync userName database collection =
    db
        .User
        .DeleteCollectionAccessLevelAsync(
            userName,
            database,
            collection
        )
        .GetAwaiter()
        .GetResult

let deleteDatabaseAccessAsync userName database =
    db
        .User
        .DeleteDatabaseAccessLevelAsync(userName, database)
        .GetAwaiter()
        .GetResult()

let deleteUserAsync userName =
    db
        .User
        .DeleteUserAsync(userName)
        .GetAwaiter()
        .GetResult()

let getUserAsync userName =
    db
        .User
        .GetUserAsync(userName)
        .GetAwaiter()
        .GetResult()

let getUsersAsync () =
    db.User.GetUsersAsync().GetAwaiter().GetResult()

let patchUserAsync userName (newUserMetadata: (string * bool * Dictionary<string, obj>)) =
    let password, active, extra = newUserMetadata
    let patchedUser = PatchUserBody(Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PatchUserAsync(userName, patchedUser)
        .GetAwaiter()
        .GetResult()

let postUserAsync (newUserMetadata: (string * string * bool * Dictionary<string, obj>)) =
    let userName, password, active, extra = newUserMetadata

    let newUser =
        PostUserBody(User = userName, Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PostUserAsync(newUser)
        .GetAwaiter()
        .GetResult()

let putCollectionAccessAsync userName database collection accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutCollectionAccessLevelAsync(
            userName,
            database,
            collection,
            PutAccessLevelBody(Grant = access)
        )
        .GetAwaiter()
        .GetResult

let putDatabaseAccessAsync userName database accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutDatabaseAccessLevelAsync(userName, database, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

let putUserAsync userName (newUserMetadata: (string * bool * Dictionary<string, obj>)) =
    let password, active, extra = newUserMetadata
    let replacedUser = PutUserBody(Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PutUserAsync(userName, replacedUser)
        .GetAwaiter()
        .GetResult()
