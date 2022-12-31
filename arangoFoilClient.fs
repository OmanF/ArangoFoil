module ArangoFoilClient

open System
open FsHttp
open ArangoDBNetStandard
open ArangoDBNetStandard.Transport.Http

open ArangoDBNetStandard.UserApi.Models
open ArangoDBNetStandard.CollectionApi.Models
open ArangoDBNetStandard.DocumentApi.Models
open ArangoDBNetStandard.GraphApi.Models
open ArangoDBNetStandard.CursorApi.Models
open ArangoDBNetStandard.Serialization

open type Transport.Http.HttpApiTransport

type ArangoFoilClient() =
    let mutable db =
        new ArangoDBClient(new HttpApiTransport(new Net.Http.HttpClient(), HttpContentType.Json))

    member this.bindBasicAuthConnection
        (runHealthCheck: bool)
        (url: string)
        (dbName: string)
        (userName: string)
        (password: string)
        =
        // Default values for the root user, connecting to the `_system` database on a local instance of ArangoDB, running on Docker, taken from the official image:
        // URL: "http://localhost:8529", Database: "_system", Username: "root", Password: "openSesame"
        db <- new ArangoDBClient(UsingBasicAuth(new Uri(url), dbName, userName, password))

        if (runHealthCheck = true) then
            match
                (http {
                    GET $"%s{url}/_admin/status"
                    AuthorizationUserPw userName password
                 }
                 |> Request.send)
                    .statusCode
            with
            | Net.HttpStatusCode.OK -> ()
            | _ -> failwith $"Health check on the server at %s{url} failed!"
        else
            ()

    // `Users` API
    // -------------------------------------------
    // #region
    member this.deleteCollectionAccessLevel(username, dbName, collectionName) =
        db
            .User
            .DeleteCollectionAccessLevelAsync(username, dbName, collectionName)
            .GetAwaiter()
            .GetResult()

    member this.deleteDatabaseAccessLevel(username, dbName) =
        db
            .User
            .DeleteDatabaseAccessLevelAsync(username, dbName)
            .GetAwaiter()
            .GetResult()


    member this.deleteUser(username) =
        db.User.DeleteUserAsync(username).GetAwaiter().GetResult()

    member this.getAccessibleDatabases(username, ?query: GetAccessibleDatabasesQuery) =
        let query = defaultArg query null
        db.User.GetAccessibleDatabasesAsync(username, query).GetAwaiter().GetResult()

    member this.getCollectionAccessLevel(username, dbName, collectionName) =
        db
            .User
            .GetCollectionAccessLevelAsync(username, dbName, collectionName)
            .GetAwaiter()
            .GetResult()

    member this.getDatabaseAccessLevel(username, dbName) =
        db.User.GetDatabaseAccessLevelAsync(username, dbName).GetAwaiter().GetResult()

    member this.getUser(username) =
        db.User.GetUserAsync(username).GetAwaiter().GetResult()

    member this.getUsers() =
        db.User.GetUsersAsync().GetAwaiter().GetResult()

    member this.patchUser(username, body) =
        db.User.PatchUserAsync(username, body).GetAwaiter().GetResult()

    member this.postUser(body) =
        db.User.PostUserAsync(body).GetAwaiter().GetResult()

    member this.putCollectionAccessLevel(username, dbName, collectionName, body) =
        db
            .User
            .PutCollectionAccessLevelAsync(username, dbName, collectionName, body)
            .GetAwaiter()
            .GetResult()

    member this.putDatabaseAccessLevel(username, dbName, body) =
        db
            .User
            .PutDatabaseAccessLevelAsync(username, dbName, body)
            .GetAwaiter()
            .GetResult()

    member this.putUser(username, body) =
        db.User.PutUserAsync(username, body).GetAwaiter().GetResult()
    // #endregion

    // `Databases` API
    // -------------------------------------------
    // #region
    member this.deleteDatabase(databaseName) =
        db.Database.DeleteDatabaseAsync(databaseName).GetAwaiter().GetResult()

    member this.getCurrentDatabaseInfo() =
        db.Database.GetCurrentDatabaseInfoAsync().GetAwaiter().GetResult()

    member this.getDatabases() =
        db.Database.GetDatabasesAsync().GetAwaiter().GetResult()

    member this.getUserDatabases() =
        db.Database.GetUserDatabasesAsync().GetAwaiter().GetResult()

    member this.postDatabase(request) =
        db.Database.PostDatabaseAsync(request).GetAwaiter().GetResult()
    // #endregion

    // `Collections` API
    // -------------------------------------------
    // #region
    member this.deleteCollection(collectionName) =
        db.Collection.DeleteCollectionAsync(collectionName).GetAwaiter().GetResult()

    member this.getChecksum(collectionName, ?query: GetChecksumQuery) =
        let query = defaultArg query null
        db.Collection.GetChecksumAsync(collectionName, query).GetAwaiter().GetResult()

    member this.getCollection(collectionName) =
        db.Collection.GetCollectionAsync(collectionName).GetAwaiter().GetResult()

    member this.getCollectionCount(collectionName) =
        db.Collection.GetCollectionCountAsync(collectionName).GetAwaiter().GetResult()

    member this.getCollectionFigures(collectionName) =
        db.Collection.GetCollectionFiguresAsync(collectionName).GetAwaiter().GetResult()

    member this.getCollectionProperties(collectionName) =
        db
            .Collection
            .GetCollectionPropertiesAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    member this.getCollectionRevision(collectionName) =
        db
            .Collection
            .GetCollectionRevisionAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    member this.getCollections(?query: GetCollectionsQuery) =
        let query = defaultArg query null
        db.Collection.GetCollectionsAsync(query).GetAwaiter().GetResult()

    member this.getCollectionShards(collectionName) =
        db.Collection.GetCollectionShardsAsync(collectionName).GetAwaiter().GetResult()

    member this.getCollectionShardsWithDetails(collectionName) =
        db
            .Collection
            .GetCollectionShardsWithDetailsAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    member this.postCollection(body, ?options: PostCollectionQuery) =
        let options = defaultArg options null
        db.Collection.PostCollectionAsync(body, options).GetAwaiter().GetResult()

    member this.putCollectionProperty(collectionName, body) =
        db
            .Collection
            .PutCollectionPropertyAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    member this.putCompactCollectionData(collectionName) =
        db
            .Collection
            .PutCompactCollectionDataAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    member this.putDocumentShard(collectionName, body) =
        db
            .Collection
            .PutDocumentShardAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    member this.putLoadIndexesIntoMemory(collectionName) =
        db
            .Collection
            .PutLoadIndexesIntoMemoryAsync(collectionName)
            .GetAwaiter()
            .GetResult()

    member this.putRecalculateCount(collectionName) =
        db.Collection.PutRecalculateCountAsync(collectionName).GetAwaiter().GetResult()

    member this.renameCollection(collectionName, body) =
        db
            .Collection
            .RenameCollectionAsync(collectionName, body)
            .GetAwaiter()
            .GetResult()

    member this.truncateCollection(collectionName) =
        db.Collection.TruncateCollectionAsync(collectionName).GetAwaiter().GetResult()
    // #endregion

    // `Documents` API
    // -------------------------------------------
    // #region
    member this.deleteDocument(documentId, ?query: DeleteDocumentQuery, ?headers: DocumentHeaderProperties) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentAsync(documentId, query, headers)
            .GetAwaiter()
            .GetResult()

    member this.deleteDocument
        (
            collectionName,
            documentKey,
            ?query: DeleteDocumentQuery,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentAsync(collectionName, documentKey, query, headers)
            .GetAwaiter()
            .GetResult()

    member this.deleteDocuments
        (
            collectionName,
            selectors,
            ?query: DeleteDocumentsQuery,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentsAsync(collectionName, selectors, query, headers)
            .GetAwaiter()
            .GetResult()

    member this.getDocument(documentId, ?headers: DocumentHeaderProperties) =
        let headers = defaultArg headers null
        db.Document.GetDocumentAsync(documentId, headers).GetAwaiter().GetResult()

    member this.getDocument(collectionName, documentKey, ?headers: DocumentHeaderProperties) =
        let headers = defaultArg headers null

        db
            .Document
            .GetDocumentAsync(collectionName, documentKey, headers)
            .GetAwaiter()
            .GetResult()

    member this.getDocuments<'T>(collectionName, selectors, ?headers: DocumentHeaderProperties) =
        let headers = defaultArg headers null

        db
            .Document
            .GetDocumentsAsync<'T>(collectionName, selectors, headers)
            .GetAwaiter()
            .GetResult()

    member this.headDocument(documentId, ?headers: DocumentHeaderProperties) =
        let headers = defaultArg headers null
        db.Document.HeadDocumentAsync(documentId, headers).GetAwaiter().GetResult()

    member this.headDocument(collectionName, documentKey, ?headers: DocumentHeaderProperties) =
        let headers = defaultArg headers null

        db
            .Document
            .HeadDocumentAsync(collectionName, documentKey, headers)
            .GetAwaiter()
            .GetResult()

    member this.patchDocument<'T, 'U>
        (
            documentId,
            body: 'T,
            ?query: PatchDocumentQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PatchDocumentAsync<'T, 'U>(documentId, body, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.patchDocument<'T, 'U>
        (
            collectionName,
            documentKey,
            body: 'T,
            ?query: PatchDocumentQuery,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .PatchDocumentAsync<'T, 'U>(collectionName, documentKey, body, query, headers)
            .GetAwaiter()
            .GetResult()

    member this.patchDocuments<'T, 'U>
        (
            collectionName,
            patches,
            ?query: PatchDocumentsQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let headers = defaultArg headers null
        let apiSerOpts = defaultArg apiSerOpts null
        let query = defaultArg query null

        db
            .Document
            .PatchDocumentsAsync<'T, 'U>(collectionName, patches, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.postDocument<'T>
        (
            collectionName,
            document: 'T,
            ?query: PostDocumentsQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentAsync<'T>(collectionName, document, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.postDocument<'T, 'U>
        (
            collectionName,
            document: 'T,
            ?query: PostDocumentsQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let apiSerOpts = defaultArg apiSerOpts null
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentAsync<'T, 'U>(collectionName, document, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.postDocuments(collectionName, documents, ?query, ?apiSerOpts, ?headers) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentsAsync(collectionName, documents, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.putDocument<'T>
        (
            documentId,
            doc: 'T,
            ?opts: PutDocumentQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let opts = defaultArg opts null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentAsync<'T>(documentId, doc, opts, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    member this.putDocument<'T>
        (
            collectionName,
            documentKey,
            doc: 'T,
            ?opts: PutDocumentQuery,
            ?headers: DocumentHeaderProperties
        ) =
        let opts = defaultArg opts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentAsync<'T>(collectionName, documentKey, doc, opts, headers)
            .GetAwaiter()
            .GetResult()

    member this.putDocuments
        (
            collectionName,
            documents,
            ?query: PutDocumentsQuery,
            ?apiSerOpts: ApiClientSerializationOptions,
            ?headers: DocumentHeaderProperties
        ) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentsAsync(collectionName, documents, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()
    // #endregion

    // `Views` API
    // -------------------------------------------
    // #region
    member this.deleteView(viewNameOrId) =
        db.View.DeleteViewAsync(viewNameOrId).GetAwaiter().GetResult()

    member this.getAllViews() =
        db.View.GetAllViewsAsync().GetAwaiter().GetResult()

    member this.getView(viewNameOrId) =
        db.View.GetViewAsync(viewNameOrId).GetAwaiter().GetResult()

    member this.getViewProperties(viewNameOrId) =
        db.View.GetViewPropertiesAsync(viewNameOrId).GetAwaiter().GetResult()

    member this.patchViewProperties(viewNameOrId, ?body) =
        let body = defaultArg body null

        db.View.PatchViewPropertiesAsync(viewNameOrId, body).GetAwaiter().GetResult()

    member this.postCreateView(body) =
        db.View.PostCreateViewAsync(body).GetAwaiter().GetResult()

    member this.putRenameView(viewName, body) =
        db.View.PutRenameViewAsync(viewName, body).GetAwaiter().GetResult()

    member this.putViewProperties(viewName, body) =
        db.View.PutViewPropertiesAsync(viewName, body).GetAwaiter().GetResult()
    // #endregion

    // `Graphs` API
    // -------------------------------------------
    // #region
    member this.deleteEdge(graphName, documentId, ?query: DeleteEdgeQuery) =
        let query = defaultArg query null
        db.Graph.DeleteEdgeAsync(graphName, documentId, query).GetAwaiter().GetResult()

    member this.deleteEdge(graphName, collectionName, edgeKey, ?query: DeleteEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeAsync(graphName, collectionName, edgeKey, query)
            .GetAwaiter()
            .GetResult()

    member this.deleteEdgeDefinition(graphName, collectionName, ?query: DeleteEdgeDefinitionQuery) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteEdgeDefinitionAsync(graphName, collectionName, query)
            .GetAwaiter()
            .GetResult()

    member this.deleteGraph(graphName, ?query: DeleteGraphQuery) =
        let query = defaultArg query null
        db.Graph.DeleteGraphAsync(graphName, query).GetAwaiter().GetResult()

    member this.deleteVertex(graphName, documentId, ?query: DeleteVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteVertexAsync(graphName, documentId, query)
            .GetAwaiter()
            .GetResult()

    member this.deleteVertex(graphName, collectionName, vertexKey, ?query: DeleteVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteVertexAsync(graphName, collectionName, vertexKey, query)
            .GetAwaiter()
            .GetResult()

    member this.deleteVertexCollection(graphName, collectionName, ?query: DeleteVertexCollectionQuery) =
        let query = defaultArg query null

        db
            .Graph
            .DeleteVertexCollectionAsync(graphName, collectionName, query)
            .GetAwaiter()
            .GetResult()

    member this.getEdge(graphName, edgeHandle, ?query: GetEdgeQuery) =
        let query = defaultArg query null

        db.Graph.GetEdgeAsync(graphName, edgeHandle, query).GetAwaiter().GetResult()

    member this.getEdge(graphName, collectionName, edgeKey, ?query: GetEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .GetEdgeAsync(graphName, collectionName, edgeKey, query)
            .GetAwaiter()
            .GetResult()

    member this.getEdgeCollections(graphName) =
        db.Graph.GetEdgeCollectionsAsync(graphName).GetAwaiter().GetResult()

    member this.getGraph(graphName) =
        db.Graph.GetGraphAsync(graphName).GetAwaiter().GetResult()

    member this.getGraphs() =
        db.Graph.GetGraphsAsync().GetAwaiter().GetResult()

    member this.getVertex(graphName, documentId, ?query: GetVertexQuery) =
        let query = defaultArg query null

        db.Graph.GetVertexAsync(graphName, documentId, query).GetAwaiter().GetResult()

    member this.getVertex(graphName, collectionName, vertexKey, ?query: GetVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .GetVertexAsync(graphName, collectionName, vertexKey, query)
            .GetAwaiter()
            .GetResult()

    member this.getVertexCollections(graphName) =
        db.Graph.GetVertexCollectionsAsync(graphName).GetAwaiter().GetResult()

    member this.patchEdge<'T, 'U>(graphName, documentId, edge: 'T, ?query: PatchEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PatchEdgeAsync(graphName, documentId, edge, query)
            .GetAwaiter()
            .GetResult()

    member this.patchEdge<'T, 'U>(graphName, collectionName, edgeKey, edge: 'T, ?query: PatchEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PatchEdgeAsync(graphName, collectionName, edgeKey, edge, query)
            .GetAwaiter()
            .GetResult()

    member this.patchVertex<'T, 'U>(graphName, documentId, body: 'T, ?query: PatchVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PatchVertexAsync(graphName, documentId, body, query)
            .GetAwaiter()
            .GetResult()

    member this.patchVertex<'T, 'U>(graphName, collectionName, vertexKey, body: 'T, ?query: PatchVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PatchVertexAsync(graphName, collectionName, vertexKey, body, query)
            .GetAwaiter()
            .GetResult()

    member this.postEdge
        (
            graphName,
            collectionName,
            edge,
            ?query: PostEdgeQuery,
            ?apiSerOpts: ApiClientSerializationOptions
        ) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null

        db
            .Graph
            .PostEdgeAsync(graphName, collectionName, edge, query, apiSerOpts)
            .GetAwaiter()
            .GetResult()

    member this.postEdgeDefinition(graphName, body) =
        db.Graph.PostEdgeDefinitionAsync(graphName, body).GetAwaiter().GetResult()

    member this.postGraph(postGraphBody, ?query: PostGraphQuery) =
        let query = defaultArg query null

        db.Graph.PostGraphAsync(postGraphBody, query).GetAwaiter().GetResult()

    member this.postVertex
        (
            graphName,
            collectionName,
            vertex,
            ?query: PostVertexQuery,
            ?apiSerOpts: ApiClientSerializationOptions
        ) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null

        db
            .Graph
            .PostVertexAsync(graphName, collectionName, vertex, query, apiSerOpts)
            .GetAwaiter()
            .GetResult()

    member this.postVertexCollection(graphName, body) =
        db.Graph.PostVertexCollectionAsync(graphName, body).GetAwaiter().GetResult()

    member this.putEdge<'T>(graphName, documentId, edge: 'T, ?query: PutEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeAsync(graphName, documentId, edge, query)
            .GetAwaiter()
            .GetResult()

    member this.putEdge<'T>(graphName, collectionName, edgeKey, edge: 'T, ?query: PutEdgeQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeAsync(graphName, collectionName, edgeKey, edge, query)
            .GetAwaiter()
            .GetResult()

    member this.putEdgeDefinition(graphName, collectionName, body, ?query) =
        let query = defaultArg query null

        db
            .Graph
            .PutEdgeDefinitionAsync(graphName, collectionName, body, query)
            .GetAwaiter()
            .GetResult()

    member this.putVertex<'T>(graphName, doucmentId, vertex: 'T, ?query: PutVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PutVertexAsync(graphName, doucmentId, vertex, query)
            .GetAwaiter()
            .GetResult()

    member this.putVertex<'T>(graphName, collectionName, key, vertex: 'T, ?query: PutVertexQuery) =
        let query = defaultArg query null

        db
            .Graph
            .PutVertexAsync(graphName, collectionName, key, vertex, query)
            .GetAwaiter()
            .GetResult()
    // #endregion

    // `Cursors` API
    // -------------------------------------------
    // #region
    member this.deleteCursor(cursorId) =
        db.Cursor.DeleteCursorAsync(cursorId).GetAwaiter().GetResult()

    member this.postCursor(postCursorBody, ?headers: CursorHeaderProperties) =
        let headers = defaultArg headers null

        db.Cursor.PostCursorAsync(postCursorBody, headers).GetAwaiter().GetResult()

    member this.putCursor(cursorId) =
        db.Cursor.PostAdvanceCursorAsync(cursorId).GetAwaiter().GetResult()
// #endregion
