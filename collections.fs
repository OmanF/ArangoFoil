module Collections

open ArangoDBNetStandard.CollectionApi.Models
open ConnectionDetails

type UserCollectionType =
    | Document
    | Edge

let getCollectionsAsync () =
    db
        .Collection
        .GetCollectionsAsync()
        .GetAwaiter()
        .GetResult()

let getCollectionAsync collectionName =
    db
        .Collection
        .GetCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()

let createCollectionAsync collectionName collectionType =
    let body =
        match collectionType with
        | Document -> PostCollectionBody(Name = collectionName, Type = CollectionType.Document)
        | Edge -> PostCollectionBody(Name = collectionName, Type = CollectionType.Edge)

    db
        .Collection
        .PostCollectionAsync(body)
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
        .TruncateCollectionAsync(
            collectionName
        )
        .GetAwaiter()
        .GetResult

let deleteCollectionAsync collectionName =
    db
        .Collection
        .DeleteCollectionAsync(
            collectionName
        )
        .GetAwaiter()
        .GetResult
