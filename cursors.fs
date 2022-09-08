module Cursors

open HelperFunctions
open ArangoDBNetStandard.CursorApi.Models
open System
open System.Collections.Generic
open ConnectionDetails

type UnofficialPostCursorOptionsOptimizer = { Rules: IEnumerable<string> }

type UnofficialPostCursorOptions =
    { FailOnWarning: Nullable<bool>
      FullCount: Nullable<bool>
      IntermediateCommitCount: Nullable<int64>
      IntermediateCommitSize: Nullable<int64>
      MaxPlans: Nullable<int64>
      MaxRuntime: Nullable<double>
      MaxTransactionSize: Nullable<int64>
      MaxWarningCount: Nullable<int64>
      Optimizer: UnofficialPostCursorOptionsOptimizer
      Profile: Nullable<int32>
      SatelliteSyncWait: Nullable<double>
      SkipInaccessibleCollections: Nullable<bool>
      Stream: Nullable<bool> }

type UnofficialPostCursorBody =
    { BatchSize: Nullable<int64>
      BindVars: Dictionary<string, obj>
      Cache: Nullable<bool>
      Count: Nullable<bool>
      MemoryLimit: Nullable<int64>
      Query: string
      Ttl: Nullable<int32>
      Options: UnofficialPostCursorOptions }

type UnofficialCursorHeaders = { TransactionId: string }

let deleteCursorAsync cursorId =
    db
        .Cursor
        .DeleteCursorAsync(cursorId)
        .GetAwaiter()
        .GetResult()

let postCursorAsync<'T> (postCursorBody: UnofficialPostCursorBody) (headers: UnofficialCursorHeaders option) =
    let headers =
        Option.defaultValue Unchecked.defaultof<UnofficialCursorHeaders> headers

    db
        .Cursor
        .PostCursorAsync<'T>(
            PostCursorBody(
                BatchSize = postCursorBody.BatchSize,
                BindVars = postCursorBody.BindVars,
                Cache = postCursorBody.Cache,
                Count = postCursorBody.Count,
                MemoryLimit = postCursorBody.MemoryLimit,
                Query = postCursorBody.Query,
                Ttl = postCursorBody.Ttl,
                Options =
                    PostCursorOptions(
                        FailOnWarning = postCursorBody.Options.FailOnWarning,
                        FullCount = postCursorBody.Options.FullCount,
                        IntermediateCommitCount = postCursorBody.Options.IntermediateCommitCount,
                        IntermediateCommitSize = postCursorBody.Options.IntermediateCommitSize,
                        MaxPlans = postCursorBody.Options.MaxPlans,
                        MaxRuntime = postCursorBody.Options.MaxRuntime,
                        MaxTransactionSize = postCursorBody.Options.MaxTransactionSize,
                        MaxWarningCount = postCursorBody.Options.MaxWarningCount,
                        Optimizer = PostCursorOptionsOptimizer(Rules = postCursorBody.Options.Optimizer.Rules),
                        Profile = postCursorBody.Options.Profile,
                        SatelliteSyncWait = postCursorBody.Options.SatelliteSyncWait,
                        SkipInaccessibleCollections = postCursorBody.Options.SkipInaccessibleCollections,
                        Stream = postCursorBody.Options.Stream
                    )
            ),
            CursorHeaderProperties(TransactionId = headers.TransactionId)
        )
        .GetAwaiter()
        .GetResult()

let putCursorAsync<'T> cursorId =
    db
        .Cursor
        .PutCursorAsync<'T>(cursorId)
        .GetAwaiter()
        .GetResult()
