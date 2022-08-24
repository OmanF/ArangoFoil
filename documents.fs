module Documents

open System
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.Serialization
open ConnectionDetails

let deleteDocumentByIdAsync documentId (deleteDocumentQueryOption: DeleteDocumentQuery option) =
    let dcq =
        match deleteDocumentQueryOption with
        | Some dcq -> dcq
        | None -> null

    db
        .Document
        .DeleteDocumentAsync(documentId, dcq)
        .GetAwaiter()
        .GetResult()

let deleteDocumentByCollectionKeyAsync
    collectionName
    documentKey
    (deleteDocumentQueryOption: DeleteDocumentQuery option)
    =
    let dcq =
        match deleteDocumentQueryOption with
        | Some dcq -> dcq
        | None -> null

    db
        .Document
        .DeleteDocumentAsync(collectionName, documentKey, dcq)
        .GetAwaiter()
        .GetResult()

let deleteDocumentsAsync
    collectionName
    (documents: Collections.Generic.IList<string>)
    (deleteDocumentsQueryOption: DeleteDocumentsQuery option)
    =
    let ddq =
        match deleteDocumentsQueryOption with
        | Some ddq -> ddq
        | None -> null

    db
        .Document
        .DeleteDocumentsAsync(collectionName, documents, ddq)
        .GetAwaiter()
        .GetResult()

let getDocumentByIdAsync<'T> documentId =
    db
        .Document
        .GetDocumentAsync<'T>(documentId)
        .GetAwaiter()
        .GetResult()

let getDocumentByCollectionKeyAsync<'T> collectionName documentKey =
    db
        .Document
        .GetDocumentAsync<'T>(collectionName, documentKey)
        .GetAwaiter()
        .GetResult()

let getDocumentsAsync<'T> collectionName documentsKeys =
    db
        .Document
        .GetDocumentsAsync<'T>(collectionName, documentsKeys)
        .GetAwaiter()
        .GetResult()

let patchDocumentByIdAsync<'T, 'U>
    documentId
    (replaceDocument: 'T)
    (patchDocumentQueryOption: PatchDocumentQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdq =
        match patchDocumentQueryOption with
        | Some pdq -> pdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PatchDocumentAsync(documentId, replaceDocument, pdq, aso)
        .GetAwaiter()
        .GetResult()

let patchDocumentByCollectionKeyAsync<'T, 'U>
    (collectionName: string)
    (documentKey: string)
    (replacementDocument: 'T)
    (patchDocumentQueryOption: PatchDocumentQuery option)
    =
    let pdq =
        match patchDocumentQueryOption with
        | Some pdq -> pdq
        | None -> null

    db
        .Document
        .PatchDocumentAsync(collectionName, documentKey, replacementDocument, pdq)
        .GetAwaiter()
        .GetResult()

let patchDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (patchDocumentQueryOption: PatchDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdq =
        match patchDocumentQueryOption with
        | Some pdq -> pdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PatchDocumentsAsync(collectionName, documents, pdq, aso)
        .GetAwaiter()
        .GetResult()

let postDocumentAsync<'T>
    collectionName
    document
    (createDocumentQueryOption: PostDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdq =
        match createDocumentQueryOption with
        | Some pdq -> pdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PostDocumentAsync<'T>(collectionName, document, pdq, aso)
        .GetAwaiter()
        .GetResult()

let postDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (createDocumentQueryOption: PostDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdq =
        match createDocumentQueryOption with
        | Some pdq -> pdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PostDocumentsAsync<'T>(collectionName, documents, pdq, aso)
        .GetAwaiter()
        .GetResult()

let putDocumentByIdAsync<'T>
    documentId
    (replaceDocument: 'T)
    (replaceDocumentQueryOption: PutDocumentQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let rdq =
        match replaceDocumentQueryOption with
        | Some rdq -> rdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PutDocumentAsync(documentId, replaceDocument, rdq, aso)
        .GetAwaiter()
        .GetResult()

let putDocumentByCollectionKeyAsync<'T>
    collectionName
    documentKey
    (replacementDocument: 'T)
    (replaceDocumentQueryOption: PutDocumentQuery option)
    =
    let rdq =
        match replaceDocumentQueryOption with
        | Some rdq -> rdq
        | None -> null

    db
        .Document
        .PutDocumentAsync(collectionName, documentKey, replacementDocument, rdq)
        .GetAwaiter()
        .GetResult()

let putDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (replaceDocumentQueryOption: PutDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let rdq =
        match replaceDocumentQueryOption with
        | Some rdq -> rdq
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PutDocumentsAsync(collectionName, documents, rdq, aso)
        .GetAwaiter()
        .GetResult()
