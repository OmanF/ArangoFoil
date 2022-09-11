namespace Cursors

open ConnectionDetails

type Cursors =
    static member deleteCursorAsync(cursorId) =
        db
            .Cursor
            .DeleteCursorAsync(cursorId)
            .GetAwaiter()
            .GetResult()

    static member postCursorAsync(postCursorBody, ?headers) =
        let headers = defaultArg headers null

        db
            .Cursor
            .PostCursorAsync(postCursorBody, headers)
            .GetAwaiter()
            .GetResult()

    static member putCursorAsync(cursorId) =
        db
            .Cursor
            .PutCursorAsync(cursorId)
            .GetAwaiter()
            .GetResult()
