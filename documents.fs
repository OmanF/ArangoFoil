module Documents

open System
open HelperFunctions
open ConnectionDetails
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.Serialization

type UnofficialDeleteDocumentQuery =
    { ReturnOld: Nullable<bool>
      Silent: Nullable<bool>
      WaitForSync: Nullable<bool> }

type UnofficialDeleteDocumentsQuery =
    { IgnoreRevs: Nullable<bool>
      ReturnOld: Nullable<bool>
      Silent: Nullable<bool>
      WaitForSync: Nullable<bool> }

type UnofficialPatchDocumentQuery =
    { IgnoreRevs: Nullable<bool>
      KeepNull: Nullable<bool>
      MergeObjects: Nullable<bool>
      ReturnNew: Nullable<bool>
      ReturnOld: Nullable<bool>
      Silent: Nullable<bool>
      WaitForSync: Nullable<bool> }

type UnofficialPostDocumentsQuery =
    { Overwrite: Nullable<bool>
      ReturnNew: Nullable<bool>
      ReturnOld: Nullable<bool>
      Silent: Nullable<bool>
      WaitForSync: Nullable<bool> }

type UnofficialPutDocumentQuery =
    { IgnoreRevs: Nullable<bool>
      ReturnNew: Nullable<bool>
      ReturnOld: Nullable<bool>
      Silent: Nullable<bool>
      WaitForSync: Nullable<bool> }

type UnofficialDocumentHeaders =
    { IfMatch: string
      IfNoneMatch: string
      TransactionId: string }

let deleteDocumentByIdAsync
    documentId
    (query: UnofficialDeleteDocumentQuery option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialDeleteDocumentQuery> query

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .DeleteDocumentAsync(
            documentId,
            DeleteDocumentQuery(ReturnOld = query.ReturnOld, Silent = query.Silent, WaitForSync = query.WaitForSync),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let deleteDocumentByCollectionKeyAsync
    collectionName
    documentKey
    (query: UnofficialDeleteDocumentQuery option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialDeleteDocumentQuery> query

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .DeleteDocumentAsync(
            collectionName,
            documentKey,
            DeleteDocumentQuery(ReturnOld = query.ReturnOld, Silent = query.Silent, WaitForSync = query.WaitForSync),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let deleteDocumentsAsync
    collectionName
    (selectors: Collections.Generic.IList<string>)
    (query: UnofficialDeleteDocumentsQuery option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialDeleteDocumentsQuery> query

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .DeleteDocumentsAsync(
            collectionName,
            selectors,
            DeleteDocumentsQuery(
                IgnoreRevs = query.IgnoreRevs,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let getDocumentByIdAsync<'T> documentId (headers: UnofficialDocumentHeaders option) =
    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .GetDocumentAsync<'T>(
            documentId,
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let getDocumentByCollectionKeyAsync<'T> collectionName documentKey (headers: UnofficialDocumentHeaders option) =
    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .GetDocumentAsync<'T>(
            collectionName,
            documentKey,
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let getDocumentsAsync<'T> collectionName selectors (headers: UnofficialDocumentHeaders option) =
    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .GetDocumentsAsync<'T>(
            collectionName,
            selectors,
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let patchDocumentByIdAsync<'T, 'U>
    documentId
    (body: 'T)
    (query: UnofficialPatchDocumentQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPatchDocumentQuery> query

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PatchDocumentAsync(
            documentId,
            body,
            PatchDocumentQuery(
                IgnoreRevs = query.IgnoreRevs,
                KeepNull = query.KeepNull,
                MergeObjects = query.MergeObjects,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let patchDocumentByCollectionKeyAsync<'T, 'U>
    collectionName
    documentKey
    (body: 'T)
    (query: UnofficialPatchDocumentQuery option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPatchDocumentQuery> query

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PatchDocumentAsync(
            collectionName,
            documentKey,
            body,
            PatchDocumentQuery(
                IgnoreRevs = query.IgnoreRevs,
                KeepNull = query.KeepNull,
                MergeObjects = query.MergeObjects,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let patchDocumentsAsync<'T>
    collectionName
    (patches: Collections.Generic.IList<'T>)
    (query: UnofficialPatchDocumentQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPatchDocumentQuery> query

    db
        .Document
        .PatchDocumentsAsync(
            collectionName,
            patches,
            PatchDocumentsQuery(
                IgnoreRevs = query.IgnoreRevs,
                KeepNull = query.KeepNull,
                MergeObjects = query.MergeObjects,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let postDocumentAsync<'T>
    collectionName
    (document: 'T)
    (query: UnofficialPostDocumentsQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPostDocumentsQuery> query

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PostDocumentAsync<'T>(
            collectionName,
            document,
            PostDocumentsQuery(
                Overwrite = query.Overwrite,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let postDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (query: UnofficialPostDocumentsQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPostDocumentsQuery> query

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PostDocumentsAsync<'T>(
            collectionName,
            documents,
            PostDocumentsQuery(
                Overwrite = query.Overwrite,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let putDocumentByIdAsync<'T>
    documentId
    (doc: 'T)
    (opts: UnofficialPutDocumentQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let opts = Option.defaultValue Unchecked.defaultof<UnofficialPutDocumentQuery> opts

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PutDocumentAsync(
            documentId,
            doc,
            PutDocumentQuery(
                IgnoreRevs = opts.IgnoreRevs,
                ReturnNew = opts.ReturnNew,
                ReturnOld = opts.ReturnOld,
                Silent = opts.Silent,
                WaitForSync = opts.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let putDocumentByCollectionKeyAsync<'T>
    collectionName
    documentKey
    (doc: 'T)
    (opts: UnofficialPutDocumentQuery option)
    (headers: UnofficialDocumentHeaders option)
    =
    let opts = Option.defaultValue Unchecked.defaultof<UnofficialPutDocumentQuery> opts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PutDocumentAsync(
            collectionName,
            documentKey,
            doc,
            PutDocumentQuery(
                IgnoreRevs = opts.IgnoreRevs,
                ReturnNew = opts.ReturnNew,
                ReturnOld = opts.ReturnOld,
                Silent = opts.Silent,
                WaitForSync = opts.WaitForSync
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()

let putDocumentsAsync<'T>
    collectionName
    (documents: Collections.Generic.IList<'T>)
    (query: UnofficialPutDocumentQuery option)
    (apiSerOpts: UnofficialApiClientSerializationOptions option)
    (headers: UnofficialDocumentHeaders option)
    =
    let query =
        Option.defaultValue Unchecked.defaultof<UnofficialPutDocumentQuery> query

    let apiSerOpts =
        Option.defaultValue Unchecked.defaultof<UnofficialApiClientSerializationOptions> apiSerOpts

    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialDocumentHeaders> headers

    db
        .Document
        .PutDocumentsAsync(
            collectionName,
            documents,
            PutDocumentsQuery(
                IgnoreRevs = query.IgnoreRevs,
                ReturnNew = query.ReturnNew,
                ReturnOld = query.ReturnOld,
                Silent = query.Silent,
                WaitForSync = query.WaitForSync
            ),
            ApiClientSerializationOptions(
                ignoreNullValues = apiSerOpts.IgnoreNullValues,
                useCamelCasePropertyNames = apiSerOpts.UseCamelCasePropertyNames,
                useStringEnumConversion = apiSerOpts.UseStringEnumConversion
            ),
            DocumentHeaderProperties(
                IfMatch = headers.IfMatch,
                IfNoneMatch = headers.IfNoneMatch,
                TransactionId = headers.TransactionId
            )
        )
        .GetAwaiter()
        .GetResult()
