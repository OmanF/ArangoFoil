module Collections

open ArangoDBNetStandard.CollectionApi.Models
open HelperFunctions
open ConnectionDetails
open System

type GetCollection = { ExcludeSystem: Nullable<bool> }

type UnofficialCollectionType =
    | Document
    | Edge

type UnofficialKeyOptions =
    { AllowUserKeys: bool
      Increment: Int64
      Offset: Int64
      Type: string }

type UnofficialPostCollectionBody =
    { DistributedShardsLike: string option
      DoCompact: Nullable<bool>
      IndexBuckets: Nullable<Int32>
      IsSystem: Nullable<bool>
      IsVolatile: Nullable<bool>
      JournalSize: Nullable<Int64>
      KeyOptions: UnofficialKeyOptions option
      Name: string
      NumberOfShards: Nullable<Int32>
      ReplicationFactor: Nullable<Int32>
      ShardingStrategy: string option
      ShardKeys: seq<string> option
      SmartJoinAttribute: string option
      Type: UnofficialCollectionType
      WaitForSync: Nullable<bool> }

type UnofficialPostCollectionQuery =
    { EnforceReplicationFactor: Nullable<bool>
      WaitForSyncReplication: Nullable<bool> }

type UnofficialRenameCollectionBody = { Name: string }

let deleteCollectionAsync collectionName =
    db
        .Collection
        .DeleteCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()

let getCollectionAsync collectionName =
    db
        .Collection
        .GetCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()

let getCollectionsAsync (query: GetCollection option) =
    let excludeSystems =
        match query with
        | Some query -> query.ExcludeSystem
        | None -> Nullable()

    db
        .Collection
        .GetCollectionsAsync(GetCollectionsQuery(ExcludeSystem = excludeSystems))
        .GetAwaiter()
        .GetResult()

let postCollectionAsync (body: UnofficialPostCollectionBody) (options: UnofficialPostCollectionQuery option) =
    let keyOptions =
        Option.defaultValue Unchecked.defaultof<UnofficialKeyOptions> body.KeyOptions

    db
        .Collection
        .PostCollectionAsync(
            PostCollectionBody(
                DistributeShardsLike = Option.defaultValue "" body.DistributedShardsLike,
                DoCompact = body.DoCompact,
                IndexBuckets = body.IndexBuckets,
                IsSystem = body.IsSystem,
                IsVolatile = body.IsVolatile,
                KeyOptions =
                    CollectionKeyOptions(
                        AllowUserKeys = keyOptions.AllowUserKeys,
                        Increment = keyOptions.Increment,
                        Offset = keyOptions.Offset,
                        Type = keyOptions.Type
                    ),
                Name = body.Name,
                NumberOfShards = body.NumberOfShards,
                ReplicationFactor = body.ReplicationFactor,
                ShardingStrategy = Option.defaultValue null body.ShardingStrategy,
                ShardKeys = Option.defaultValue (seq { "_key" }) body.ShardKeys,
                SmartJoinAttribute = Option.defaultValue null body.SmartJoinAttribute,
                WaitForSync = body.WaitForSync,
                Type =
                    match body.Type with
                    | Document -> CollectionType.Document
                    | Edge -> CollectionType.Edge
            ),
            match options with
            | Some options ->
                PostCollectionQuery(
                    EnforceReplicationFactor = options.EnforceReplicationFactor,
                    WaitForSyncReplication = options.WaitForSyncReplication
                )
            | None -> null
        )
        .GetAwaiter()
        .GetResult()

let renameCollectionAsync collectionName (body: UnofficialRenameCollectionBody) =
    db
        .Collection
        .RenameCollectionAsync(collectionName, RenameCollectionBody(Name = body.Name))
        .GetAwaiter()
        .GetResult()

let truncateCollectionAsync collectionName =
    db
        .Collection
        .TruncateCollectionAsync(collectionName)
        .GetAwaiter()
        .GetResult()
