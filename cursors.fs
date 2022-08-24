module Cursors

open ArangoDBNetStandard.CursorApi.Models
open ConnectionDetails

let deleteCursorAsync cursorId =
    db
        .Cursor
        .DeleteCursorAsync(cursorId)
        .GetAwaiter()
        .GetResult()

let postCursorAsync<'T> (cursorBody: PostCursorBody) =
    db
        .Cursor
        .PostCursorAsync<'T>(cursorBody)
        .GetAwaiter()
        .GetResult()

let putCursorAsync<'T> cursorId =
    db
        .Cursor
        .PutCursorAsync<'T>(cursorId)
        .GetAwaiter()
        .GetResult()
