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
    ///  写真名
    ///  注意　PhotoBase64項目の記載がない場合無視されます
    /// </summary>
    public string? PhotoName{get;set;}

    /// <summary>
    ///  写真Base64
    ///  注意　PhotoName項目の記載がない場合は無視されます
    /// </summary>
    public string? PhotoBase64 {get;set;}

    /// <summary>
    /// 住所
    /// </summary>
    public string? Address{get;set;}
}