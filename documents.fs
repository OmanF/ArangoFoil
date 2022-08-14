module Documents

open System
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.Serialization
open ConnectionDetails

let deleteDocumentByIdAsync documentId (deleteDocumentOptions: DeleteDocumentQuery option) =
    let dco =
        match deleteDocumentOptions with
        | Some dco -> dco
        | None -> null

    db
        .Document
        .DeleteDocumentAsync(documentId, dco)
        .GetAwaiter()
        .GetResult()

let deleteDocumentByCollectionKeyAsync collectionName documentKey (deleteDocumentOptions: DeleteDocumentQuery option) =
    let dco =
        match deleteDocumentOptions with
        | Some dco -> dco
        | None -> null

    db
        .Document
        .DeleteDocumentAsync(collectionName, documentKey, dco)
        .GetAwaiter()
        .GetResult()

let deleteDocumentsAsync
    collectionName
    (documents: Collections.Generic.IList<string>)
    (deleteDocumentsOptions: DeleteDocumentsQuery option)
    =
    let ddo =
        match deleteDocumentsOptions with
        | Some ddo -> ddo
        | None -> null

    db
        .Document
        .DeleteDocumentsAsync(collectionName, documents, ddo)
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
    (patchDocumentOption: PatchDocumentQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdo =
        match patchDocumentOption with
        | Some pdo -> pdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PatchDocumentAsync(documentId, replaceDocument, pdo, aso)
        .GetAwaiter()
        .GetResult()

let patchDocumentByCollectionKeyAsync<'T, 'U>
    (collectionName: string)
    (documentKey: string)
    (replacementDocument: 'T)
    (patchDocumentOption: PatchDocumentQuery option)
    =
    let pdo =
        match patchDocumentOption with
        | Some pdo -> pdo
        | None -> null

    db
        .Document
        .PatchDocumentAsync(collectionName, documentKey, replacementDocument, pdo)
        .GetAwaiter()
        .GetResult()

let patchDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (patchDocumentOption: PatchDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdo =
        match patchDocumentOption with
        | Some pdo -> pdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PatchDocumentsAsync(collectionName, documents, pdo, aso)
        .GetAwaiter()
        .GetResult()

let createDocumentAsync<'T>
    collectionName
    document
    (createDocumentOptions: PostDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdo =
        match createDocumentOptions with
        | Some pdo -> pdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PostDocumentAsync<'T>(collectionName, document, pdo, aso)
        .GetAwaiter()
        .GetResult()

let createDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (createDocumentOptions: PostDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let pdo =
        match createDocumentOptions with
        | Some pdo -> pdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PostDocumentsAsync<'T>(collectionName, documents, pdo, aso)
        .GetAwaiter()
        .GetResult()

let replaceDocumentByIdAsync<'T>
    documentId
    (replaceDocument: 'T)
    (replaceDocumentOptions: PutDocumentQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let rdo =
        match replaceDocumentOptions with
        | Some rdo -> rdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PutDocumentAsync(documentId, replaceDocument, rdo, aso)
        .GetAwaiter()
        .GetResult()

let replaceDocumentByCollectionKeyAsync<'T>
    collectionName
    documentKey
    (replacementDocument: 'T)
    (replaceDocumentOptions: PutDocumentQuery option)
    =
    let rdo =
        match replaceDocumentOptions with
        | Some rdo -> rdo
        | None -> null

    db
        .Document
        .PutDocumentAsync(collectionName, documentKey, replacementDocument, rdo)
        .GetAwaiter()
        .GetResult()

let replaceDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (replaceDocumentOptions: PutDocumentsQuery option)
    (apiSerializationOption: ApiClientSerializationOptions option)
    =
    let rdo =
        match replaceDocumentOptions with
        | Some rdo -> rdo
        | None -> null

    let aso =
        match apiSerializationOption with
        | Some aso -> aso
        | None -> null

    db
        .Document
        .PutDocumentsAsync(collectionName, documents, rdo, aso)
        .GetAwaiter()
        .GetResult()
