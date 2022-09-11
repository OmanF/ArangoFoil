namespace Documents

open ConnectionDetails

type Documents =
    static member deleteDocumentAsync(documentId, ?query, ?headers) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentAsync(documentId, query, headers)
            .GetAwaiter()
            .GetResult()

    static member deleteDocumentAsync(collectionName, documentKey, ?query, ?headers) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentAsync(collectionName, documentKey, query, headers)
            .GetAwaiter()
            .GetResult()

    static member deleteDocumentsAsync(collectionName, selectors, ?query, ?headers) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .DeleteDocumentsAsync(collectionName, selectors, query, headers)
            .GetAwaiter()
            .GetResult()

    static member getDocumentAsync(documentId, ?headers) =
        let headers = defaultArg headers null

        db
            .Document
            .GetDocumentAsync(documentId, headers)
            .GetAwaiter()
            .GetResult()

    static member getDocumentAsync(collectionName, documentKey, ?headers) =
        let headers = defaultArg headers null

        db
            .Document
            .GetDocumentAsync(collectionName, documentKey, headers)
            .GetAwaiter()
            .GetResult()

    static member getDocumentsAsync<'T>(collectionName, selectors, ?headers) =
        let headers = defaultArg headers null

        db
            .Document
            .GetDocumentsAsync<'T>(collectionName, selectors, headers)
            .GetAwaiter()
            .GetResult()

    static member headDocumentAsync(documentId, ?headers) =
        let headers = defaultArg headers null

        db
            .Document
            .HeadDocumentAsync(documentId, headers)
            .GetAwaiter()
            .GetResult()

    static member headDocumentAsync(collectionName, documentKey, ?headers) =
        let headers = defaultArg headers null

        db
            .Document
            .HeadDocumentAsync(collectionName, documentKey, headers)
            .GetAwaiter()
            .GetResult()

    static member patchDocumentAsync<'T, 'U>(documentId, (body: 'T), ?query, ?apiSerOpts, ?headers) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PatchDocumentAsync<'T, 'U>(documentId, body, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member patchDocumentAsync<'T, 'U>(collectionName, documentKey, (body: 'T), ?query, ?headers) =
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .PatchDocumentAsync<'T, 'U>(collectionName, documentKey, body, query, headers)
            .GetAwaiter()
            .GetResult()

    static member patchDocumentsAsync<'T, 'U>(collectionName, patches, ?query, ?apiSerOpts, ?headers) =
        let headers = defaultArg headers null
        let apiSerOpts = defaultArg apiSerOpts null
        let query = defaultArg query null

        db
            .Document
            .PatchDocumentsAsync<'T, 'U>(collectionName, patches, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member postDocumentAsync<'T>(collectionName, (document: 'T), ?query, ?apiSerOpts, ?headers) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentAsync<'T>(collectionName, document, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member postDocumentAsync<'T, 'U>(collectionName, (document: 'T), ?query, ?apiSerOpts, ?headers) =
        let apiSerOpts = defaultArg apiSerOpts null
        let query = defaultArg query null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentAsync<'T, 'U>(collectionName, document, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member postDocumentsAsync(collectionName, documents, ?query, ?apiSerOpts, ?headers) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PostDocumentsAsync(collectionName, documents, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member putDocumentAsync<'T>(documentId, (doc: 'T), ?opts, ?apiSerOpts, ?headers) =
        let opts = defaultArg opts null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentAsync<'T>(documentId, doc, opts, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()

    static member putDocumentAsync<'T>(collectionName, documentKey, (doc: 'T), ?opts, ?headers) =
        let opts = defaultArg opts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentAsync<'T>(collectionName, documentKey, doc, opts, headers)
            .GetAwaiter()
            .GetResult()

    static member putDocumentsAsync(collectionName, documents, ?query, ?apiSerOpts, ?headers) =
        let query = defaultArg query null
        let apiSerOpts = defaultArg apiSerOpts null
        let headers = defaultArg headers null

        db
            .Document
            .PutDocumentsAsync(collectionName, documents, query, apiSerOpts, headers)
            .GetAwaiter()
            .GetResult()
