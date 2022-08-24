module Views

open ArangoDBNetStandard.ViewApi.Models
open ConnectionDetails

let deleteViewAsync viewName =
    db
        .View
        .DeleteViewAsync(viewName)
        .GetAwaiter()
        .GetResult()

let getAllViewsAsync () =
    db
        .View
        .GetAllViewsAsync()
        .GetAwaiter()
        .GetResult()

let getViewAsync viewName =
    db
        .View
        .GetViewAsync(viewName)
        .GetAwaiter()
        .GetResult()

let getViewPropertiesAsync viewName =
    db
        .View
        .GetViewPropertiesAsync(viewName)
        .GetAwaiter()
        .GetResult()

let patchViewPropertiesAsync viewName (viewMetadata: ViewDetails) =
    db
        .View
        .PatchViewPropertiesAsync(viewName, viewMetadata)
        .GetAwaiter()
        .GetResult()

let postViewAsync (viewMetadata: ViewDetails) =
    db
        .View
        .PostCreateViewAsync(viewMetadata)
        .GetAwaiter()
        .GetResult()

let putViewAsync viewName newViewName =
    db
        .View
        .PutRenameViewAsync(viewName, PutRenameViewBody(Name = newViewName))
        .GetAwaiter()
        .GetResult()

let putViewPropertiesAsync viewName (viewMetadata: ViewDetails) =
    db
        .View
        .PutViewPropertiesAsync(viewName, viewMetadata)
        .GetAwaiter()
        .GetResult()
