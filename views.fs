namespace Views

open ConnectionDetails

type Views =
    static member deleteViewAsync(viewNameOrId) =
        db
            .View
            .DeleteViewAsync(viewNameOrId)
            .GetAwaiter()
            .GetResult()

    static member getAllViewsAsync() =
        db
            .View
            .GetAllViewsAsync()
            .GetAwaiter()
            .GetResult()

    static member getViewAsync(viewNameOrId) =
        db
            .View
            .GetViewAsync(viewNameOrId)
            .GetAwaiter()
            .GetResult()

    static member getViewPropertiesAsync(viewNameOrId) =
        db
            .View
            .GetViewPropertiesAsync(viewNameOrId)
            .GetAwaiter()
            .GetResult()

    static member patchViewPropertiesAsync(viewNameOrId, ?body) =
        let body = defaultArg body null

        db
            .View
            .PatchViewPropertiesAsync(viewNameOrId, body)
            .GetAwaiter()
            .GetResult()

    static member postCreateViewAsync(body) =
        db
            .View
            .PostCreateViewAsync(body)
            .GetAwaiter()
            .GetResult()

    static member putRenameViewAsync(viewName, body) =
        db
            .View
            .PutRenameViewAsync(viewName, body)
            .GetAwaiter()
            .GetResult()

    static member putViewPropertiesAsync(viewName, body) =
        db
            .View
            .PutViewPropertiesAsync(viewName, body)
            .GetAwaiter()
            .GetResult()
