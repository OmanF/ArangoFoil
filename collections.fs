module Collections

open ArangoDBNetStandard.CollectionApi.Models
open HelperFunctions
open ConnectionDetails

type CollectionType =
    | Document
    | Edge

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

let postCollectionAsync name collectionType collectionKeysOption newCollectionExtraData createCollectionQueryOption =
    let collectionTypeString =
        match collectionType with
        | Document -> "document"
        | Edge -> "edge"

    let postCollectionBody, postCollectionQuery =
        createPostCollectionBodyObject
            name
            collectionTypeString
            collectionKeysOption
            newCollectionExtraData
            createCollectionQueryOption

    db
        .Collection
        .PostCollectionAsync(postCollectionBody, postCollectionQuery)
        .GetAwaiter()
        .GetResult()

let renameCollectionAsync currentCollectionName newCollectionName =
    db
        .Collection
        .RenameCollectionAsync(currentCollectionName, RenameCollectionBody(Name = newCollectionName))
        .GetAwaiter()
        .GetResult()

let truncateCollectionAsync collectionName =
    db
        .Collection
        .TruncateCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()
