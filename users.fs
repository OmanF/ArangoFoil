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

///<summary>
/// Revoke access of the specified user to the specified collection.
/// Can only be run by a user with access to the "_system" database.
/// </summary>
/// <param name="userName">The user whose access is being revoked.</param>
/// <param name="database">The database containing the target collection.</param>
/// <param name="collection">The target collection.</param>
let deleteCollectionAccessAsync userName database collection =
    db
        .User
        .DeleteCollectionAccessLevelAsync(userName, database, collection)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Revoke access of the specified user to the specified database.
/// Can only be run by a user with access to the "_system" database.
/// </summary>
/// <param name="userName">The user whose access is being revoked.</param>
/// <param name="database">The target database.</param>
let deleteDatabaseAccessAsync userName database =
    db
        .User
        .DeleteDatabaseAccessLevelAsync(userName, database)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Completely remove a user from the system.
/// **This can NOT be undone once executed!**
/// Can only be run by a user with access to the "_system" database.
/// </summary>
/// <param name="userName">The user being deleted.</param>
let deleteUserAsync userName =
    db
        .User
        .DeleteUserAsync(userName)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Retrieve data about a specific user.
/// Non-administrative users can get data only about their own user.
/// Administrative users (i.e., users with access to the "_system" database) can get data on all users.
/// </summary>
/// <param name="userName">The user to retrieve data about.</param>
let getUserAsync userName =
    db
        .User
        .GetUserAsync(userName)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Retrieve data about all system's users.
/// Non-administrative users will only get data only about their own user!
/// Administrative users (i.e., users with access to the "_system" database) can get data on all users.
/// </summary>
let getUsersAsync () =
    db.User.GetUsersAsync().GetAwaiter().GetResult()

///<summary>
/// Partially update user's details.
/// Non-administrative users can only update their own details.
/// Administrative users (i.e., users with access to the "_system" database) can update all users.
/// </summary>
/// <param name="userName">The user to update.</param>
/// <param name="newUserMetaData">The updated details. A **tuple** of password (a `string`), user's active status (as `bool`) and extra details (as a `Dictionary&lt;string, obj&gt;`. See official driver's documentation to see what extra details can be passed).</param>
let patchUserAsync userName (newUserMetadata: (string * bool * Dictionary<string, obj>)) =
    let password, active, extra = newUserMetadata
    let patchedUser = PatchUserBody(Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PatchUserAsync(userName, patchedUser)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Update user's details.
/// Non-administrative users can only update their own details.
/// Administrative users (i.e., users with access to the "_system" database) can update all users.
/// </summary>
/// <param name="userName">The user to update.</param>
/// <param name="newUserMetaData">The updated details. A **tuple** of new username (a `string`), password (a `string`), user's active status (as `bool`) and extra details (as a `Dictionary&lt;string, obj&gt;`. See official driver's documentation to see what extra details can be passed).</param>
let postUserAsync (newUserMetadata: (string * string * bool * Dictionary<string, obj>)) =
    let userName, password, active, extra = newUserMetadata

    let newUser =
        PostUserBody(User = userName, Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PostUserAsync(newUser)
        .GetAwaiter()
        .GetResult()

///<summary>
/// Grant access to the specified user to the specified collection.
/// Can only be run by a user with access to the "_system" database.
/// </summary>
/// <param name="userName">The user whose access is being revoked.</param>
/// <param name="database">The database containing the target collection.</param>
/// <param name="collection">The target collection.</param>
/// <param name="accessLevel">Access level to grant the user. Please use one of the following, **verbatim**: "NotAuthorized", "ReadOnly", or "ReadWrite".</param>
let putCollectionAccessAsync userName database collection accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutCollectionAccessLevelAsync(userName, database, collection, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

///<summary>
/// Grant access to the specified user to the specified database.
/// Can only be run by a user with access to the "_system" database.
/// </summary>
/// <param name="userName">The user whose access is being revoked.</param>
/// <param name="database">The database containing the target collection.</param>
/// <param name="accessLevel">Access level to grant the user. Please use one of the following, **verbatim**: "NotAuthorized", "ReadOnly", or "ReadWrite".</param>
let putDatabaseAccessAsync userName database accessLevel =
    let access = accessLevelClassifierHelperFunction accessLevel

    db
        .User
        .PutDatabaseAccessLevelAsync(userName, database, PutAccessLevelBody(Grant = access))
        .GetAwaiter()
        .GetResult()

///<summary>
/// Update user's details.
/// Non-administrative users can only update their own details.
/// Administrative users (i.e., users with access to the "_system" database) can update all users.
/// </summary>
/// <param name="userName">The user to update.</param>
/// <param name="newUserMetaData">The updated details. A **tuple** of password (a `string`), user's active status (as `bool`) and extra details (as a `Dictionary&lt;string, obj&gt;`. See official driver's documentation to see what extra details can be passed).</param>
let putUserAsync userName (newUserMetadata: (string * bool * Dictionary<string, obj>)) =
    let password, active, extra = newUserMetadata
    let replacedUser = PutUserBody(Passwd = password, Active = active, Extra = extra)

    db
        .User
        .PutUserAsync(userName, replacedUser)
        .GetAwaiter()
        .GetResult()
