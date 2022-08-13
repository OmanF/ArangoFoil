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

let getUsersAsync () =
    db.User.GetUsersAsync().GetAwaiter().GetResult()

let getUserAsync userName =
    db
        .User
        .GetUserAsync(userName)
        .GetAwaiter()
        .GetResult()

let createUserAsync userName password active =
    let isActive = Option.defaultValue true active

    db
        .User
        .PostUserAsync(PostUserBody(User = userName, Passwd = password, Active = isActive))
        .GetAwaiter()
        .GetResult()

let patchUserAsync userName password active =
    let isActive = Option.defaultValue true active

    db
        .User
        .PatchUserAsync(userName, PatchUserBody(Passwd = password, Active = isActive))
        .GetAwaiter()
        .GetResult()

let replaceUserAsync userName password active =
    let isActive = Option.defaultValue true active

    db
        .User
        .PutUserAsync(userName, PutUserBody(Passwd = password, Active = isActive))
        .GetAwaiter()
        .GetResult()

let deleteUserAsync userName =
    db
        .User
        .DeleteUserAsync(userName)
        .GetAwaiter()
        .GetResult()

let grantDatabaseAccessAsync userName database accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutDatabaseAccessLevelAsync(userName, database, PutAccessLevelBody(Grant = access))
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

let removeDatabaseAccessAsync userName database =
    db
        .User
        .DeleteDatabaseAccessLevelAsync(userName, database)
        .GetAwaiter()
        .GetResult()

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
