namespace Collections

open ConnectionDetails

type Collections =
    static member deleteCollectionAsync(collectionName) =
        db
            .Collection
            .DeleteCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionAsync(collectionName) =
        db
            .Collection
            .GetCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionsAsync(?query) =
        let query = defaultArg query null

        db
            .Collection
            .GetCollectionsAsync(query)
            .GetAwaiter()
            .GetResult()

    static member postCollectionAsync(body, ?options) =
        let options = defaultArg options null

        db
            .Collection
            .PostCollectionAsync(body, options)
            .GetAwaiter()
            .GetResult()

    static member renameCollectionAsync(collectionName, body) =
        db
            .Collection
            .RenameCollectionAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    static member truncateCollectionAsync(collectionName) =
        db
            .Collection
            .TruncateCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()
