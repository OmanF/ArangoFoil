module Documents

open System
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.Serialization
open HelperFunctions
open ConnectionDetails

let deleteDocumentByIdAsync documentId (deleteDocumentQueryOption: (bool * bool * bool) option) =
    let ddq = createDeleteDocumentQueryObject deleteDocumentQueryOption

    db
        .Document
        .DeleteDocumentAsync(documentId, ddq)
        .GetAwaiter()
        .GetResult()

let deleteDocumentByCollectionKeyAsync
    collectionName
    documentKey
    (deleteDocumentQueryOption: (bool * bool * bool) option)
    =
    let ddq = createDeleteDocumentQueryObject deleteDocumentQueryOption

    db
        .Document
        .DeleteDocumentAsync(collectionName, documentKey, ddq)
        .GetAwaiter()
        .GetResult()

let deleteDocumentsAsync
    collectionName
    (documents: Collections.Generic.IList<string>)
    (deleteDocumentsQueryOption: (bool * bool * bool * bool) option)
    =
    let ddqs = createDeleteDocumentsQueryObject deleteDocumentsQueryOption

    db
        .Document
        .DeleteDocumentsAsync(collectionName, documents, ddqs)
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
    (patchDocumentQueryOption: (bool * bool * bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let pdq = createPatchDocumentQueryObject patchDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PatchDocumentAsync(documentId, replaceDocument, pdq, aso)
        .GetAwaiter()
        .GetResult()

let patchDocumentByCollectionKeyAsync<'T, 'U>
    (collectionName: string)
    (documentKey: string)
    (replacementDocument: 'T)
    (patchDocumentQueryOption: (bool * bool * bool * bool * bool * bool * bool) option)
    =
    let pdq = createPatchDocumentQueryObject patchDocumentQueryOption

    db
        .Document
        .PatchDocumentAsync(collectionName, documentKey, replacementDocument, pdq)
        .GetAwaiter()
        .GetResult()

let patchDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (patchDocumentQueryOption: (bool * bool * bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let pdqs = createPatchDocumentsQueryObject patchDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PatchDocumentsAsync(collectionName, documents, pdqs, aso)
        .GetAwaiter()
        .GetResult()

let postDocumentAsync<'T>
    collectionName
    document
    (createDocumentQueryOption: (bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let pdq = createPostDocumentQueryObject createDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PostDocumentAsync<'T>(collectionName, document, pdq, aso)
        .GetAwaiter()
        .GetResult()

let postDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (createDocumentQueryOption: (bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let pdq = createPostDocumentQueryObject createDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PostDocumentsAsync<'T>(collectionName, documents, pdq, aso)
        .GetAwaiter()
        .GetResult()

let putDocumentByIdAsync<'T>
    documentId
    (replaceDocument: 'T)
    (replaceDocumentQueryOption: (bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let rdq = createPutDocumentQueryObject replaceDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PutDocumentAsync(documentId, replaceDocument, rdq, aso)
        .GetAwaiter()
        .GetResult()

let putDocumentByCollectionKeyAsync<'T>
    collectionName
    documentKey
    (replacementDocument: 'T)
    (replaceDocumentQueryOption: (bool * bool * bool * bool * bool) option)
    =
    let rdq = createPutDocumentQueryObject replaceDocumentQueryOption

    db
        .Document
        .PutDocumentAsync(collectionName, documentKey, replacementDocument, rdq)
        .GetAwaiter()
        .GetResult()

let putDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (replaceDocumentQueryOption: (bool * bool * bool * bool * bool) option)
    (apiSerializationOption: (bool * bool * bool) option)
    =
    let rdq = createPutDocumentsQueryObject replaceDocumentQueryOption
    let aso = createApiSerializationOptionsObject apiSerializationOption

    db
        .Document
        .PutDocumentsAsync(collectionName, documents, rdq, aso)
        .GetAwaiter()
        .GetResult()
