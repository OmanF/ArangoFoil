namespace Graphs

open ConnectionDetails

type Graphs =
    static member deleteEdgeAsync(graphName, documentId, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeAsync(graphName, documentId, query)
            .GetAwaiter()
            .GetResult()

    static member deleteEdgeAsync(graphName, collectionName, edgeKey, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeAsync(graphName, collectionName, edgeKey, query)
            .GetAwaiter()
            .GetResult()

    static member deleteEdgeDefinitionAsync(graphName, collectionName, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeDefinitionAsync(graphName, collectionName, query)
            .GetAwaiter()
            .GetResult()

    static member deleteGraphAsync(graphName, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteGraphAsync(graphName, query)
            .GetAwaiter()
            .GetResult()

    static member deleteVertexAsync(graphName, documentId, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteVertexAsync(graphName, documentId, query)
            .GetAwaiter()
            .GetResult()

    static member deleteVertexAsync(graphName, collectionName, vertexKey, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeAsync(graphName, collectionName, vertexKey, query)
            .GetAwaiter()
            .GetResult()

    static member deleteVertexCollectionAsync(graphName, collectionName, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteVertexCollectionAsync(graphName, collectionName, query)
            .GetAwaiter()
            .GetResult()

    static member getEdgeAsync(graphName, edgeHandle, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .GetEdgeAsync(graphName, edgeHandle, query)
            .GetAwaiter()
            .GetResult()

    static member getEdgeAsync(graphName, collectionName, edgeKey, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .GetEdgeAsync(graphName, collectionName, edgeKey, query)
            .GetAwaiter()
            .GetResult()

    static member getEdgeCollectionsAsync(graphName) =
        db
            .Graph
            .GetEdgeCollectionsAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member getGraphAsync(graphName) =
        db
            .Graph
            .GetGraphAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member getGraphsAsync() =
        db.Graph.GetGraphsAsync().GetAwaiter().GetResult()

    static member getVertexAsync(graphName, documentId, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .GetVertexAsync(graphName, documentId, query)
            .GetAwaiter()
            .GetResult()

    static member getVertexAsync(graphName, collectionName, vertexKey, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .GetVertexAsync(graphName, collectionName, vertexKey, query)
            .GetAwaiter()
            .GetResult()

    static member getVertexCollectionsAsync(graphName) =
        db
            .Graph
            .GetVertexCollectionsAsync(graphName)
            .GetAwaiter()
            .GetResult()

    static member patchEdgeAsync<'T, 'U>(graphName, documentId, (edge: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PatchEdgeAsync<'T, 'U>(graphName, documentId, edge, query)
            .GetAwaiter()
            .GetResult()

    static member patchEdgeAsync<'T, 'U>(graphName, collectionName, edgeKey, (edge: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PatchEdgeAsync<'T, 'U>(graphName, collectionName, edgeKey, edge, query)
            .GetAwaiter()
            .GetResult()

    static member patchVertexAsync<'T, 'U>(graphName, documentId, (body: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PatchVertexAsync<'T, 'U>(graphName, documentId, body, query)
            .GetAwaiter()
            .GetResult()

    static member patchVertexKey<'T, 'U>(graphName, collectionName, vertexKey, (body: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PatchVertexAsync<'T, 'U>(graphName, collectionName, vertexKey, body, query)
            .GetAwaiter()
            .GetResult()

    static member postEdgeAsync<'T>(graphName, collectionName, (edge: 'T), ?query, ?apiSerOpts) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null

        db
            .Graph
            .PostEdgeAsync<'T>(graphName, collectionName, edge, query, apiSerOpts)
            .GetAwaiter()
            .GetResult()

    static member postEdgeDefinitionAsync(graphName, body) =
        db
            .Graph
            .PostEdgeDefinitionAsync(graphName, body)
            .GetAwaiter()
            .GetResult()

    static member postGraphAsync(postGraphBody, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PostGraphAsync(postGraphBody, query)
            .GetAwaiter()
            .GetResult()

    static member postVertexAsync<'T>(graphName, collectionName, (vertex: 'T), ?query, ?apiSerOpts) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null

        db
            .Graph
            .PostVertexAsync<'T>(graphName, collectionName, vertex, query, apiSerOpts)
            .GetAwaiter()
            .GetResult()

    static member postVertexCollectionAsync(graphName, body) =
        db
            .Graph
            .PostVertexCollectionAsync(graphName, body)
            .GetAwaiter()
            .GetResult()

    static member putEdgeAsync<'T>(graphName, documentId, (edge: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeAsync<'T>(graphName, documentId, edge, query)
            .GetAwaiter()
            .GetResult()

    static member putEdgeAsync<'T>(graphName, collectionName, edgeKey, (edge: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeAsync<'T>(graphName, collectionName, edgeKey, edge, query)
            .GetAwaiter()
            .GetResult()

    static member putEdgeDefinitionAsync(graphName, collectionName, body, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeDefinitionAsync(graphName, collectionName, body, query)
            .GetAwaiter()
            .GetResult()

    static member putVertexAsync<'T>(graphName, doucmentId, (vertex: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutVertexAsync<'T>(graphName, doucmentId, vertex, query)
            .GetAwaiter()
            .GetResult()

    static member putVertexAsync<'T>(graphName, collectionName, key, (vertex: 'T), ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutVertexAsync<'T>(graphName, collectionName, key, vertex, query)
            .GetAwaiter()
            .GetResult()
