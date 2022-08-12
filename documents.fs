module Documents

open ArangoDBNetStandard
open ArangoDBNetStandard.DocumentApi.Models
open System
open ConnectionDetails

let inline getDocumentsAsync<'T> collectionName documentsKeys =
    try
        Ok
        <| db
            .Document
            .GetDocumentsAsync<'T>(collectionName, documentsKeys)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline getDocumentByIdAsync<'T> documentId =
    try
        Ok
        <| db
            .Document
            .GetDocumentAsync<'T>(documentId)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline getDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) =
    try
        Ok
        <| db
            .Document
            .GetDocumentAsync<'T>(collectionName, documentKey)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline createDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    try
        Ok
        <| db
            .Document
            .PostDocumentsAsync<'T>(collectionName, documents)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline createDocumentAsync<'T> collectionName document =
    try
        Ok
        <| db
            .Document
            .PostDocumentAsync<'T>(collectionName, document)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline patchDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    try
        Ok
        <| db
            .Document
            .PatchDocumentsAsync(collectionName, documents)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline patchDocumentByIdAsync<'T> documentId (replaceDocument: 'T) =
    try
        Ok
        <| db
            .Document
            .PatchDocumentAsync(documentId, replaceDocument)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline patchDocumentByCollectionKeyAsync<'T>
    (collectionName: string)
    (documentKey: string)
    (replacementDocument: 'T)
    =
    try
        Ok
        <| db
            .Document
            .PatchDocumentAsync(collectionName, documentKey, replacementDocument)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline replaceDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    try
        Ok
        <| db
            .Document
            .PutDocumentsAsync(collectionName, documents)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline replaceDocumentByIdAsync<'T> documentId (replaceDocument: 'T) =
    try
        Ok
        <| db
            .Document
            .PutDocumentAsync(documentId, replaceDocument)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline replaceDocumentByCollectionKeyAsync<'T>
    (collectionName: string)
    (documentKey: string)
    (replacementDocument: 'T)
    =
    try
        Ok
        <| db
            .Document
            .PutDocumentAsync(collectionName, documentKey, replacementDocument)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline deleteDocumentsAsync collectionName (documents: Collections.Generic.IList<string>) =
    try
        Ok
        <| db
            .Document
            .DeleteDocumentsAsync(collectionName, documents)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline deleteDocumentByIdAsync<'T> documentId =
    try
        Ok
        <| db
            .Document
            .DeleteDocumentAsync(documentId)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex

let inline deleteDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) =
    try
        Ok
        <| db
            .Document
            .PutDocumentAsync(collectionName, documentKey)
            .GetAwaiter()
            .GetResult()

    with
    | :? Net.Http.HttpRequestException
    | :? ArgumentException
    | :? ApiErrorException
    | :? UriFormatException as ex -> Error ex
