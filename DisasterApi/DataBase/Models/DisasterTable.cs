using Amazon.DynamoDBv2.DataModel;

namespace DisasterAPI.DataBase.Models;

/// <summary>
///     災害管理用テーブル
/// </summary>
[DynamoDBTable("disaster")]
public class DisasterTable{
    
    /// <summary>
    ///  パーティションキー  管理用ID
    /// </summary>
    [DynamoDBHashKey("id")]
    public string? Guid{get; set;}

    /// <summary>
    ///  GPS情報
    /// </summary>
    [DynamoDBProperty("gps")]
    public string? Gps{get;set;}
    
    /// <summary>
    ///     DisasterEnumの値を格納する
    /// </summary>
    [DynamoDBRangeKey("disaster_type")]
    public int DisasterType{get;set;}

    /// <summary>
    /// 住所
    /// </summary>
    [DynamoDBProperty("address")]
    public string? Address{get;set;}

    /// <summary>
    /// 　画像ファイルの格納先
    /// </summary>
    [DynamoDBProperty("file_path")]
    public string? FilePath{get;set;}

    
    /// <summary>
    ///  ipv4アドレス
    /// </summary>
    [DynamoDBProperty("ip_v4")]
    public string? Ipv4{get;set;}

    /// <summary>
    /// ipv6アドレス
　    /// </summary>
    [DynamoDBProperty("ip_v6")]
    public string? Ipv6{get;set;}

}