module Graphs

open ArangoDBNetStandard.GraphApi.Models
open ConnectionDetails

let deleteEdgeByIdAsync graphName documentId (returnOld: bool option) (waitForSync: bool option) =
    let returnOld = Option.defaultValue false returnOld
    let waitForSync = Option.defaultValue false waitForSync

    db
        .Graph
        .DeleteEdgeAsync(graphName, documentId, DeleteEdgeQuery(ReturnOld = returnOld, WaitForSync = waitForSync))
        .GetAwaiter()
        .GetResult()

let deleteEdgeByGraphCollectionKeyAsync
    graphName
    collectionName
    edgeKey
    (returnOld: bool option)
    (waitForSync: bool option)
    =
    let returnOld = Option.defaultValue false returnOld
    let waitForSync = Option.defaultValue false waitForSync

    db
        .Graph
        .DeleteEdgeAsync(
            graphName,
            collectionName,
            edgeKey,
            DeleteEdgeQuery(ReturnOld = returnOld, WaitForSync = waitForSync)
        )
        .GetAwaiter()
        .GetResult()

let deleteEdgeDefinitionAsync graphName collectionName (dropCollections: bool option) (waitForSync: bool option) =
    let dropCollections = Option.defaultValue false dropCollections
    let waitForSync = Option.defaultValue false waitForSync

    db
        .Graph
        .DeleteEdgeDefinitionAsync(
            graphName,
            collectionName,
            DeleteEdgeDefinitionQuery(DropCollections = dropCollections, WaitForSync = waitForSync)
        )
        .GetAwaiter()
        .GetResult()

let deleteGraphAsync graphName (dropCollections: bool option) =
    let dropCollections = Option.defaultValue false dropCollections

    db
        .Graph
        .DeleteGraphAsync(graphName, DeleteGraphQuery(DropCollections = dropCollections))
        .GetAwaiter()
        .GetResult()

let deleteVertexByIdAsync graphName documentId (returnOld: bool option) (waitForSync: bool option) =
    let returnOld = Option.defaultValue false returnOld
    let waitForSync = Option.defaultValue false waitForSync

    db
        .Graph
        .DeleteVertexAsync(graphName, documentId, DeleteVertexQuery(ReturnOld = returnOld, WaitForSync = waitForSync))
        .GetAwaiter()
        .GetResult()

let deleteVertexByGraphCollectionKeyAsync
    graphName
    collectionName
    vertexKey
    (returnOld: bool option)
    (waitForSync: bool option)
    =
    let returnOld = Option.defaultValue false returnOld
    let waitForSync = Option.defaultValue false waitForSync

    db
        .Graph
        .DeleteEdgeAsync(
            graphName,
            collectionName,
            vertexKey,
            DeleteEdgeQuery(ReturnOld = returnOld, WaitForSync = waitForSync)
        )
        .GetAwaiter()
        .GetResult()

let deleteVertexCollectionAsync graphName collectionName (dropCollections: bool option) =
    let dropCollections = Option.defaultValue false dropCollections

    db
        .Graph
        .DeleteVertexCollectionAsync(
            graphName,
            collectionName,
            DeleteVertexCollectionQuery(DropCollection = dropCollections)
        )
        .GetAwaiter()
        .GetResult()
