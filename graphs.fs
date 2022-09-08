module Graphs

open ArangoDBNetStandard.GraphApi.Models
open ConnectionDetails

type Graphs =
    static member deleteEdgeByIdAsync graphName documentId (returnOld: bool option) (waitForSync: bool option) =
        let returnOld = Option.defaultValue false returnOld
        let waitForSync = Option.defaultValue false waitForSync

        db
            .Graph
            .DeleteEdgeAsync(graphName, documentId, DeleteEdgeQuery(ReturnOld = returnOld, WaitForSync = waitForSync))
            .GetAwaiter()
            .GetResult()

    static member deleteEdgeByGraphCollectionKeyAsync
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

    static member deleteEdgeDefinitionAsync
        graphName
        collectionName
        (dropCollections: bool option)
        (waitForSync: bool option)
        =
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

    static member deleteGraphAsync graphName (dropCollections: bool option) =
        let dropCollections = Option.defaultValue false dropCollections

        db
            .Graph
            .DeleteGraphAsync(graphName, DeleteGraphQuery(DropCollections = dropCollections))
            .GetAwaiter()
            .GetResult()

    static member deleteVertexByIdAsync graphName documentId (returnOld: bool option) (waitForSync: bool option) =
        let returnOld = Option.defaultValue false returnOld
        let waitForSync = Option.defaultValue false waitForSync

        db
            .Graph
            .DeleteVertexAsync(
                graphName,
                documentId,
                DeleteVertexQuery(ReturnOld = returnOld, WaitForSync = waitForSync)
            )
            .GetAwaiter()
            .GetResult()

    static member deleteVertexByGraphCollectionKeyAsync
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

    static member deleteVertexCollectionAsync graphName collectionName (dropCollections: bool option) =
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

    static member getEdgeByHandleAsync graphName edgeHandle (rev: string option) =
        let rev = Option.defaultValue "" rev

        db
            .Graph
            .GetEdgeAsync(graphName, edgeHandle, GetEdgeQuery(Rev = rev))
            .GetAwaiter()
            .GetResult()

    static member getEdgeByCollectionKeyAsync graphName collectionName edgeKey (rev: string option) =
        let rev = Option.defaultValue "" rev

        db
            .Graph
            .GetEdgeAsync(graphName, collectionName, edgeKey, GetEdgeQuery(Rev = rev))
            .GetAwaiter()
            .GetResult()

    static member getEdgeCollectionsAsync graphName =
        db
            .Graph
            .GetEdgeCollectionsAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member getGraphAsync graphName =
        db
            .Graph
            .GetGraphAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member getGraphsAsync() =
        db.Graph.GetGraphsAsync().GetAwaiter().GetResult()

    static member getVertexByIdAsync graphName documentId (rev: bool option) =
        let rev = Option.defaultValue false rev

        db
            .Graph
            .GetVertexAsync(graphName, documentId, GetVertexQuery(Rev = rev))
            .GetAwaiter()
            .GetResult()

    static member getVertexByCollectionKeyAsync graphName collectionName vertexKey (rev: bool option) =
        let rev = Option.defaultValue false rev

        db
            .Graph
            .GetVertexAsync(graphName, collectionName, vertexKey, GetVertexQuery(Rev = rev))
            .GetAwaiter()
            .GetResult()

    static member getVertexCollectionsAsync graphName =
        db
            .Graph
            .GetVertexCollectionsAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member patchEdgeByIdAsync<'T, 'U>
        graphName
        documentId
        (edge: 'T)
        (patchEdgeQueryOption: PatchEdgeQuery option)
        =
        let peq =
            match patchEdgeQueryOption with
            | Some peq -> peq
            | None -> null

        db
            .Graph
            .PatchEdgeAsync(graphName, documentId, edge, peq)
            .GetAwaiter()
            .GetResult()

    static member patchEdgeByCollectionKeyAsync<'T, 'U>
        graphName
        collectionName
        edgeKey
        (edge: 'T)
        (patchEdgeQueryOption: PatchEdgeQuery option)
        =
        let peq =
            match patchEdgeQueryOption with
            | Some peq -> peq
            | None -> null

        db
            .Graph
            .PatchEdgeAsync(graphName, collectionName, edgeKey, edge, peq)
            .GetAwaiter()
            .GetResult()

    static member patchVertexByIdAsync<'T, 'U>
        graphName
        documentId
        (body: 'T)
        (patchVertexQueryOption: PatchVertexQuery option)
        =
        let pvq =
            match patchVertexQueryOption with
            | Some pvq -> pvq
            | None -> null

        db
            .Graph
            .PatchVertexAsync(graphName, documentId, body, pvq)
            .GetAwaiter()
            .GetResult()

    static member patchVertexByCollectionKey<'T, 'U>
        graphName
        collectionName
        vertexKey
        (body: 'T)
        (patchVertexQueryOption: PatchVertexQuery option)
        =
        let pvq =
            match patchVertexQueryOption with
            | Some pvq -> pvq
            | None -> null

        db
            .Graph
            .PatchVertexAsync(graphName, collectionName, vertexKey, body, pvq)
            .GetAwaiter()
            .GetResult()
