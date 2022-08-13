module Documents

open System
open ConnectionDetails

let getDocumentsAsync<'T> collectionName documentsKeys =
    db
        .Document
        .GetDocumentsAsync<'T>(collectionName, documentsKeys)
        .GetAwaiter()
        .GetResult()

let getDocumentByIdAsync<'T> documentId =
    db
        .Document
        .GetDocumentAsync<'T>(documentId)
        .GetAwaiter()
        .GetResult()

let getDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) =
    db
        .Document
        .GetDocumentAsync<'T>(collectionName, documentKey)
        .GetAwaiter()
        .GetResult()

let createDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    db
        .Document
        .PostDocumentsAsync<'T>(collectionName, documents)
        .GetAwaiter()
        .GetResult()

let createDocumentAsync<'T> collectionName document =
    db
        .Document
        .PostDocumentAsync<'T>(collectionName, document)
        .GetAwaiter()
        .GetResult()

let patchDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    db
        .Document
        .PatchDocumentsAsync(collectionName, documents)
        .GetAwaiter()
        .GetResult()

let patchDocumentByIdAsync<'T> documentId (replaceDocument: 'T) =
    db
        .Document
        .PatchDocumentAsync(documentId, replaceDocument)
        .GetAwaiter()
        .GetResult()

let patchDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) (replacementDocument: 'T) =
    db
        .Document
        .PatchDocumentAsync(collectionName, documentKey, replacementDocument)
        .GetAwaiter()
        .GetResult()

let replaceDocumentsAsync<'T> collectionName (documents: Collections.Generic.IList<'T>) =
    db
        .Document
        .PutDocumentsAsync(collectionName, documents)
        .GetAwaiter()
        .GetResult()

let replaceDocumentByIdAsync<'T> documentId (replaceDocument: 'T) =
    db
        .Document
        .PutDocumentAsync(documentId, replaceDocument)
        .GetAwaiter()
        .GetResult()

let replaceDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) (replacementDocument: 'T) =
    db
        .Document
        .PutDocumentAsync(collectionName, documentKey, replacementDocument)
        .GetAwaiter()
        .GetResult()

let deleteDocumentsAsync collectionName (documents: Collections.Generic.IList<string>) =
    db
        .Document
        .DeleteDocumentsAsync(collectionName, documents)
        .GetAwaiter()
        .GetResult()

let deleteDocumentByIdAsync<'T> documentId =
    db
        .Document
        .DeleteDocumentAsync(documentId)
        .GetAwaiter()
        .GetResult()

let deleteDocumentByCollectionKeyAsync<'T> (collectionName: string) (documentKey: string) =
    db
        .Document
        .PutDocumentAsync(collectionName, documentKey)
        .GetAwaiter()
        .GetResult()
