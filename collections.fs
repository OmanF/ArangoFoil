module Collections

open ArangoDBNetStandard
open ArangoDBNetStandard.CollectionApi.Models
open System
open ConnectionDetails

type UserCollectionType =
    | Document
    | Edge

let getCollectionsAsync () =
    try
        Ok
        <| db
            .Collection
            .GetCollectionsAsync()
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let getCollectionAsync collectionName =
    try
        Ok
        <| db
            .Collection
            .GetCollectionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let createCollectionAsync collectionName collectionType =
    try
        let body =
            match collectionType with
            | Document -> PostCollectionBody(Name = collectionName, Type = CollectionType.Document)
            | Edge -> PostCollectionBody(Name = collectionName, Type = CollectionType.Edge)

        Ok
        <| db
            .Collection
            .PostCollectionAsync(body)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let renameCollectionAsync currentCollection newCollectionName =
    try
        Ok
        <| db
            .Collection
            .RenameCollectionAsync(currentCollection, RenameCollectionBody(Name = newCollectionName))
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let truncateCollectionAsync collectionName =
    try
        Ok
        <| db
            .Collection
            .TruncateCollectionAsync(
                collectionName
            )
            .GetAwaiter()
            .GetResult

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let deleteCollectionAsync collectionName =
    try
        Ok
        <| db
            .Collection
            .DeleteCollectionAsync(
                collectionName
            )
            .GetAwaiter()
            .GetResult

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex
