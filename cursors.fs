module Cursors

open ArangoDBNetStandard.CursorApi.Models
open ConnectionDetails

let deleteCursorAsync<'T> cursorId =
    db
        .Cursor
        .DeleteCursorAsync(cursorId)
        .GetAwaiter()
        .GetResult()

let createCursorAsync<'T> (cursorBody: PostCursorBody) =
    db
        .Cursor
        .PostCursorAsync<'T>(cursorBody)
        .GetAwaiter()
        .GetResult()

let manipulateCursor<'T> cursorId =
    db
        .Cursor
        .PutCursorAsync<'T>(cursorId)
        .GetAwaiter()
        .GetResult()
