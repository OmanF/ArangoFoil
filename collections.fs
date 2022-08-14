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

let getCollectionsAsync (getCollectionsOption: GetCollectionsQuery option) =
    let gco =
        match getCollectionsOption with
        | Some gco -> gco
        | None -> null

    db
        .Collection
        .GetCollectionsAsync(gco)
        .GetAwaiter()
        .GetResult()

let createCollectionAsync
    (newCollectionMetadata: PostCollectionBody)
    (createCollectionOption: PostCollectionQuery option)
    =
    let cco =
        match createCollectionOption with
        | Some cco -> cco
        | None -> null

    db
        .Collection
        .PostCollectionAsync(newCollectionMetadata, cco)
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
