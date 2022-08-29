module HelperFunctions

open ArangoDBNetStandard.Serialization
open ArangoDBNetStandard.CollectionApi.Models
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.CursorApi.Models

let createApiSerializationOptionsObject (apiSerializationOptions: (bool * bool * bool) option) =
    let aso =
        match apiSerializationOptions with
        | None -> null
        | Some (ignoreNullValues, useCamelCasePropertyNames, useStringEnumConversion) ->
            ApiClientSerializationOptions(
                ignoreNullValues = ignoreNullValues,
                useCamelCasePropertyNames = useCamelCasePropertyNames,
                useStringEnumConversion = useStringEnumConversion
            )

    aso

let createPostCollectionBodyObject
    name
    (collectionType: string)
    (collectionKeysOption: (bool * int64 * int64 * string) option)
    (extra: (string * bool * int * bool * bool * int64 * int * int * string * string array * string * bool) option)
    (createCollectionQueryOption: (bool * bool) option)
    =
    let ccq =
        match createCollectionQueryOption with
        | None -> null
        | Some (enforceReplicationFactor, waitForSyncReplication) ->
            PostCollectionQuery(
                EnforceReplicationFactor = enforceReplicationFactor,
                WaitForSyncReplication = waitForSyncReplication
            )

    let collectionType =
        match collectionType.ToLower() with
        | "document" -> CollectionType.Document
        | "edge" -> CollectionType.Edge
        | _ -> failwith "Collection type error. This shouldn't have happened!"

    let cko =
        match collectionKeysOption with
        | None -> null
        | Some (allowUserKeys, increment, offset, collectionType) ->
            CollectionKeyOptions(
                AllowUserKeys = allowUserKeys,
                Increment = increment,
                Offset = offset,
                Type = collectionType
            )

    let mutable pcb = PostCollectionBody(Name = name, Type = collectionType)

    match extra with
    | None -> ()
    | Some rest ->
        let (distributeShardsLike,
             doCompact,
             indexBuckets,
             isSystem,
             isVolatile,
             journalSize,
             numberOfShards,
             replicationFactor,
             shardingStrategy,
             shardKeys,
             smartJoinAttribute,
             waitForSync) =
            rest

        pcb <-
            PostCollectionBody(
                DistributeShardsLike = distributeShardsLike,
                DoCompact = doCompact,
                IndexBuckets = indexBuckets,
                IsSystem = isSystem,
                IsVolatile = isVolatile,
                JournalSize = journalSize,
                KeyOptions = cko,
                NumberOfShards = numberOfShards,
                ReplicationFactor = replicationFactor,
                ShardingStrategy = shardingStrategy,
                ShardKeys = shardKeys,
                SmartJoinAttribute = smartJoinAttribute,
                WaitForSync = waitForSync
            )

    (pcb, ccq)

let createDeleteDocumentQueryObject (deleteDocumentQueryOption: (bool * bool * bool) option) =
    let ddq =
        match deleteDocumentQueryOption with
        | None -> null
        | Some (returnOld, silent, waitForSync) ->
            DeleteDocumentQuery(ReturnOld = returnOld, Silent = silent, WaitForSync = waitForSync)

    ddq

let createDeleteDocumentsQueryObject (deleteDocumentsQueryOption: (bool * bool * bool * bool) option) =
    let ddqs =
        match deleteDocumentsQueryOption with
        | None -> null
        | Some (ignoreRevs, returnOld, silent, waitForSync) ->
            DeleteDocumentsQuery(
                IgnoreRevs = ignoreRevs,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    ddqs

let createPatchDocumentQueryObject (patchDocumentQueryOption: (bool * bool * bool * bool * bool * bool * bool) option) =
    let pdq =
        match patchDocumentQueryOption with
        | None -> null
        | Some (ignoreRevs, keepNull, mergeObjects, returnNew, returnOld, silent, waitForSync) ->
            PatchDocumentQuery(
                IgnoreRevs = ignoreRevs,
                KeepNull = keepNull,
                MergeObjects = mergeObjects,
                ReturnNew = returnNew,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    pdq

let createPatchDocumentsQueryObject
    (patchDocumentQueryOption: (bool * bool * bool * bool * bool * bool * bool) option)
    =
    let pdqs =
        match patchDocumentQueryOption with
        | None -> null
        | Some (ignoreRevs, keepNull, mergeObjects, returnNew, returnOld, silent, waitForSync) ->
            PatchDocumentsQuery(
                IgnoreRevs = ignoreRevs,
                KeepNull = keepNull,
                MergeObjects = mergeObjects,
                ReturnNew = returnNew,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    pdqs

let createPostDocumentQueryObject (postDocumentQueryOption: (bool * bool * bool * bool * bool) option) =
    let pdq =
        match postDocumentQueryOption with
        | None -> null
        | Some (overwrite, returnNew, returnOld, silent, waitForSync) ->
            PostDocumentsQuery(
                Overwrite = overwrite,
                ReturnNew = returnNew,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    pdq

let createPutDocumentQueryObject (putDocumentQueryOption: (bool * bool * bool * bool * bool) option) =
    let pdq =
        match putDocumentQueryOption with
        | None -> null
        | Some (ignoreRevs, returnNew, returnOld, silent, waitForSync) ->
            PutDocumentQuery(
                IgnoreRevs = ignoreRevs,
                ReturnNew = returnNew,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    pdq

let createPutDocumentsQueryObject (putDocumentQueryOption: (bool * bool * bool * bool * bool) option) =
    let pdqs =
        match putDocumentQueryOption with
        | None -> null
        | Some (ignoreRevs, returnNew, returnOld, silent, waitForSync) ->
            PutDocumentsQuery(
                IgnoreRevs = ignoreRevs,
                ReturnNew = returnNew,
                ReturnOld = returnOld,
                Silent = silent,
                WaitForSync = waitForSync
            )

    pdqs
