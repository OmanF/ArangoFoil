module Views

open ArangoDBNetStandard.ViewApi.Models
open HelperFunctions
open ConnectionDetails
open System.Collections.Generic
open System

type UnofficialViewConsolidationPolicy =
    { MinScore: Nullable<int64>
      SegmentsBytesFloor: Nullable<int64>
      SegmentsBytesMax: Nullable<int64>
      SegmentsMax: Nullable<int64>
      SegmentsMin: Nullable<int64>
      Threshold: Nullable<decimal>
      Type: string }

type UnofficialLinkProperties =
    { Analyzers: List<string>
      Fields: IDictionary<string, UnofficialLinkProperties>
      InBackground: bool
      IncludeAllFields: bool
      StoreValues: string
      TrackListPositions: bool }

type UnofficialViewSort = { Direction: string; Field: string }

type UnofficialViewStoredValue =
    { Compression: string
      Fields: List<string> }

type UnofficialViewDetails =
    // Due to its recursive nature, the `Links` field is omitted from this implementation.
    // I actually don't know how to implement it, again, to its recursive nature.
    { CleanupIntervalStep: int32
      CommitIntervalMsec: int32
      ConsolidationIntervalMsec: int32
      ConsolidationPoilcy: UnofficialViewConsolidationPolicy
      Name: string
      PrimarySort: List<UnofficialViewSort>
      PrimarySortCompression: string
      StoredValues: List<UnofficialViewStoredValue>
      Type: string
      WritebufferActive: Nullable<int32>
      WritebufferIdle: Nullable<int32>
      WritebufferSizeMax: Nullable<int32> }

type UnofficialPutRenameViewBody = { Name: string }

let deleteViewAsync viewNameOrId =
    db
        .View
        .DeleteViewAsync(viewNameOrId)
        .GetAwaiter()
        .GetResult()

let getAllViewsAsync () =
    db
        .View
        .GetAllViewsAsync()
        .GetAwaiter()
        .GetResult()

let getViewAsync viewNameOrId =
    db
        .View
        .GetViewAsync(viewNameOrId)
        .GetAwaiter()
        .GetResult()

let getViewPropertiesAsync viewNameOrId =
    db
        .View
        .GetViewPropertiesAsync(viewNameOrId)
        .GetAwaiter()
        .GetResult()

let patchViewPropertiesAsync viewNameOrId (body: UnofficialViewDetails option) =
    let body = Option.defaultValue Unchecked.defaultof<UnofficialViewDetails> body

    db
        .View
        .PatchViewPropertiesAsync(
            viewNameOrId,
            ViewDetails(
                CleanupIntervalStep = body.CleanupIntervalStep,
                CommitIntervalMsec = body.CommitIntervalMsec,
                ConsolidationIntervalMsec = body.ConsolidationIntervalMsec,
                ConsolidationPolicy =
                    ViewConsolidationPolicy(
                        MinScore = body.ConsolidationPoilcy.MinScore,
                        SegmentsBytesFloor = body.ConsolidationPoilcy.SegmentsBytesFloor,
                        SegmentsBytesMax = body.ConsolidationPoilcy.SegmentsBytesMax,
                        SegmentsMax = body.ConsolidationPoilcy.SegmentsMax,
                        SegmentsMin = body.ConsolidationPoilcy.SegmentsMin,
                        Threshold = body.ConsolidationPoilcy.Threshold,
                        Type = body.ConsolidationPoilcy.Type
                    ),
                Name = body.Name,
                PrimarySort =
                    body.PrimarySort.ConvertAll(
                        new Converter<UnofficialViewSort, ViewSort>(fun i ->
                            ViewSort(Direction = i.Direction, Field = i.Field))
                    ),
                PrimarySortCompression = body.PrimarySortCompression,
                StoredValues =
                    body.StoredValues.ConvertAll(
                        new Converter<UnofficialViewStoredValue, ViewStoredValue>(fun i ->
                            ViewStoredValue(Compression = i.Compression, Fields = i.Fields))
                    ),
                Type = body.Type,
                WritebufferActive = body.WritebufferActive,
                WritebufferIdle = body.WritebufferIdle,
                WritebufferSizeMax = body.WritebufferSizeMax
            )
        )
        .GetAwaiter()
        .GetResult()

let postCreateViewAsync (body: UnofficialViewDetails) =
    db
        .View
        .PostCreateViewAsync(
            ViewDetails(
                CleanupIntervalStep = body.CleanupIntervalStep,
                CommitIntervalMsec = body.CommitIntervalMsec,
                ConsolidationIntervalMsec = body.ConsolidationIntervalMsec,
                ConsolidationPolicy =
                    ViewConsolidationPolicy(
                        MinScore = body.ConsolidationPoilcy.MinScore,
                        SegmentsBytesFloor = body.ConsolidationPoilcy.SegmentsBytesFloor,
                        SegmentsBytesMax = body.ConsolidationPoilcy.SegmentsBytesMax,
                        SegmentsMax = body.ConsolidationPoilcy.SegmentsMax,
                        SegmentsMin = body.ConsolidationPoilcy.SegmentsMin,
                        Threshold = body.ConsolidationPoilcy.Threshold,
                        Type = body.ConsolidationPoilcy.Type
                    ),
                Name = body.Name,
                PrimarySort =
                    body.PrimarySort.ConvertAll(
                        new Converter<UnofficialViewSort, ViewSort>(fun i ->
                            ViewSort(Direction = i.Direction, Field = i.Field))
                    ),
                PrimarySortCompression = body.PrimarySortCompression,
                StoredValues =
                    body.StoredValues.ConvertAll(
                        new Converter<UnofficialViewStoredValue, ViewStoredValue>(fun i ->
                            ViewStoredValue(Compression = i.Compression, Fields = i.Fields))
                    ),
                Type = body.Type,
                WritebufferActive = body.WritebufferActive,
                WritebufferIdle = body.WritebufferIdle,
                WritebufferSizeMax = body.WritebufferSizeMax
            )
        )
        .GetAwaiter()
        .GetResult()

let putRenameViewAsync viewName (body: UnofficialPutRenameViewBody) =
    db
        .View
        .PutRenameViewAsync(viewName, PutRenameViewBody(Name = body.Name))
        .GetAwaiter()
        .GetResult()

let putViewPropertiesAsync viewName (body: UnofficialViewDetails) =
    db
        .View
        .PutViewPropertiesAsync(
            viewName,
            ViewDetails(
                CleanupIntervalStep = body.CleanupIntervalStep,
                CommitIntervalMsec = body.CommitIntervalMsec,
                ConsolidationIntervalMsec = body.ConsolidationIntervalMsec,
                ConsolidationPolicy =
                    ViewConsolidationPolicy(
                        MinScore = body.ConsolidationPoilcy.MinScore,
                        SegmentsBytesFloor = body.ConsolidationPoilcy.SegmentsBytesFloor,
                        SegmentsBytesMax = body.ConsolidationPoilcy.SegmentsBytesMax,
                        SegmentsMax = body.ConsolidationPoilcy.SegmentsMax,
                        SegmentsMin = body.ConsolidationPoilcy.SegmentsMin,
                        Threshold = body.ConsolidationPoilcy.Threshold,
                        Type = body.ConsolidationPoilcy.Type
                    ),
                Name = body.Name,
                PrimarySort =
                    body.PrimarySort.ConvertAll(
                        new Converter<UnofficialViewSort, ViewSort>(fun i ->
                            ViewSort(Direction = i.Direction, Field = i.Field))
                    ),
                PrimarySortCompression = body.PrimarySortCompression,
                StoredValues =
                    body.StoredValues.ConvertAll(
                        new Converter<UnofficialViewStoredValue, ViewStoredValue>(fun i ->
                            ViewStoredValue(Compression = i.Compression, Fields = i.Fields))
                    ),
                Type = body.Type,
                WritebufferActive = body.WritebufferActive,
                WritebufferIdle = body.WritebufferIdle,
                WritebufferSizeMax = body.WritebufferSizeMax
            )
        )
        .GetAwaiter()
        .GetResult()
