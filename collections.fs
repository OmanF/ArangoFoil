namespace Collections

open ConnectionDetails

type Collections =
    static member deleteCollectionAsync(collectionName) =
        db
            .Collection
            .DeleteCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getChecksumAsync(collectionName, ?query) =
        let query = defaultArg query null

        db
            .Collection
            .GetChecksumAsync(collectionName, query)
            .GetAwaiter()
            .GetResult()

    static member getCollectionAsync(collectionName) =
        db
            .Collection
            .GetCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionCountAsync(collectionName) =
        db
            .Collection
            .GetCollectionCountAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionFiguresAsync(collectionName) =
        db
            .Collection
            .GetCollectionFiguresAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionPropertiesAsync(collectionName) =
        db
            .Collection
            .GetCollectionPropertiesAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionRevisionAsync(collectionName) =
        db
            .Collection
            .GetCollectionRevisionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionsAsync(?query) =
        let query = defaultArg query null

        db
            .Collection
            .GetCollectionsAsync(query)
            .GetAwaiter()
            .GetResult()

    static member getCollectionShardsAsync(collectionName) =
        db
            .Collection
            .GetCollectionShardsAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member getCollectionShardsWithDetailsAsync(collectionName) =
        db
            .Collection
            .GetCollectionShardsWithDetailsAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member postCollectionAsync(body, ?options) =
        let options = defaultArg options null

        db
            .Collection
            .PostCollectionAsync(body, options)
            .GetAwaiter()
            .GetResult()

    static member putCollectionPropertyAsync(collectionName, body) =
        db
            .Collection
            .PutCollectionPropertyAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    static member putCompactCollectionDataAsync(collectionName) =
        db
            .Collection
            .PutCompactCollectionDataAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member putDocumentShardAsync(collectionName, body) =
        db
            .Collection
            .PutDocumentShardAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    static member putLoadIndexesIntoMemoryAsync(collectionName) =
        db
            .Collection
            .PutLoadIndexesIntoMemoryAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    static member putRecalculateCountAsync(collectionName) =
        db
            .Collection
            .PutRecalculateCountAsync(collectionName)
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
