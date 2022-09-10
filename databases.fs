namespace Databases

open ConnectionDetails

type Databases =
    static member deleteDatabaseAsync(databaseName) =
        db
            .Database
            .DeleteDatabaseAsync(databaseName)
            .GetAwaiter()
            .GetResult()

    static member getCurrentDatabaseInfoAsync() =
        db
            .Database
            .GetCurrentDatabaseInfoAsync()
            .GetAwaiter()
            .GetResult()

    static member getDatabasesAsync() =
        db
            .Database
            .GetDatabasesAsync()
            .GetAwaiter()
            .GetResult()

    static member getUserDatabasesAsync() =
        db
            .Database
            .GetUserDatabasesAsync()
            .GetAwaiter()
            .GetResult()

    static member postDatabaseAsync(request) =
        db
            .Database
            .PostDatabaseAsync(request)
            .GetAwaiter()
            .GetResult()
