namespace Users

open ConnectionDetails

type Users =
    static member deleteCollectionAccessAsync(username, dbName, collectionName) =
        db
            .User
            .DeleteCollectionAccessLevelAsync(username, dbName, collectionName)
            .GetAwaiter()
            .GetResult()

    static member deleteDatabaseAccessAsync(username, dbName) =
        db
            .User
            .DeleteDatabaseAccessLevelAsync(username, dbName)
            .GetAwaiter()
            .GetResult()

    static member deleteUserAsync(username) =
        db
            .User
            .DeleteUserAsync(username)
            .GetAwaiter()
            .GetResult()

    static member getUserAsync(username) =
        db
            .User
            .GetUserAsync(username)
            .GetAwaiter()
            .GetResult()

    static member getUsersAsync() =
        db.User.GetUsersAsync().GetAwaiter().GetResult()

    static member patchUserAsync(username, body) =
        db
            .User
            .PatchUserAsync(username, body)
            .GetAwaiter()
            .GetResult()

    static member postUserAsync(body) =
        db
            .User
            .PostUserAsync(body)
            .GetAwaiter()
            .GetResult()

    static member putCollectionAccessAsync(username, dbName, collectionName, body) =
        db
            .User
            .PutCollectionAccessLevelAsync(username, dbName, collectionName, body)
            .GetAwaiter()
            .GetResult()

    static member putDatabaseAccessAsync(username, dbName, body) =
        db
            .User
            .PutDatabaseAccessLevelAsync(username, dbName, body)
            .GetAwaiter()
            .GetResult()

    static member putUserAsync(username, body) =
        db
            .User
            .PutUserAsync(username, body)
            .GetAwaiter()
            .GetResult()
