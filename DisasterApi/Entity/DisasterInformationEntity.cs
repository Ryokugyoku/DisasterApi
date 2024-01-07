namespace DisasterApi.Entity;

using DisasterApi.Enum;

/// <summary>
///  災害情報を格納するためのレコード
/// </summary>
public class DisasterInformationEntity{

    /// <summary>
    ///  災害情報種別
    /// </summary>
    public DisasterType Type{get;set;}

    /// <summary>
    ///  Gps情報を格納する
    /// </summary>
    public string? Gps{get;set;}

    /// <summary>
    ///  写真Base64
    ///  
    /// </summary>
    public string? PhotoBase64 {get;set;}

    /// <summary>
    /// 住所
    /// </summary>
    public string? Address{get;set;}
}