module Collections

open ArangoDBNetStandard.CollectionApi.Models
open ConnectionDetails

let deleteCollectionAsync collectionName =
    db
        .Collection
        .DeleteCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()

let getCollectionAsync collectionName =
    db
        .Collection
        .GetCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()

let getCollectionsAsync excludeSystems =
    db
        .Collection
        .GetCollectionsAsync(GetCollectionsQuery(ExcludeSystem = excludeSystems))
        .GetAwaiter()
        .GetResult()

let createCollectionAsync
    (newCollectionMetadata: PostCollectionBody)
    (createCollectionQueryOption: PostCollectionQuery option)
    =
    let ccq =
        match createCollectionQueryOption with
        | Some ccq -> ccq
        | None -> null

    db
        .Collection
        .PostCollectionAsync(newCollectionMetadata, ccq)
        .GetAwaiter()
        .GetResult()

let renameCollectionAsync currentCollection newCollectionName =
    db
        .Collection
        .RenameCollectionAsync(currentCollection, RenameCollectionBody(Name = newCollectionName))
        .GetAwaiter()
        .GetResult()

let truncateCollectionAsync collectionName =
    db
        .Collection
        .TruncateCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()
