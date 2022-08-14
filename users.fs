module Users

open ArangoDBNetStandard.UserApi.Models
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

let removeCollectionAccessAsync userName database collection =
    db
        .User
        .DeleteCollectionAccessLevelAsync(
            userName,
            database,
            collection
        )
        .GetAwaiter()
        .GetResult

let removeDatabaseAccessAsync userName database =
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

let patchUserAsync userName (newUserMetadata: PatchUserBody) =
    db
        .User
        .PatchUserAsync(userName, newUserMetadata)
        .GetAwaiter()
        .GetResult()

let createUserAsync (newUserMetadata: PostUserBody) =
    db
        .User
        .PostUserAsync(newUserMetadata)
        .GetAwaiter()
        .GetResult()

let grantCollectionAccessAsync userName database collection accessLevel =
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

let grantDatabaseAccessAsync userName database accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutDatabaseAccessLevelAsync(userName, database, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

let replaceUserAsync userName (newUserMetadata: PutUserBody) =
    db
        .User
        .PutUserAsync(userName, newUserMetadata)
        .GetAwaiter()
        .GetResult()
