namespace Cursors

open ConnectionDetails

type Cursors =
    static member deleteCursorAsync(cursorId) =
        db
            .Cursor
            .DeleteCursorAsync(cursorId)
            .GetAwaiter()
            .GetResult()

    static member postCursorAsync<'T>(postCursorBody, ?headers) =
        let headers = defaultArg headers null

        db
            .Cursor
            .PostCursorAsync<'T>(postCursorBody, headers)
            .GetAwaiter()
            .GetResult()

    static member putCursorAsync<'T>(cursorId) =
        db
            .Cursor
            .PutCursorAsync<'T>(cursorId)
            .GetAwaiter()
            .GetResult()
