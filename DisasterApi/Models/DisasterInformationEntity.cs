namespace DisasterApi.Models;

using DisasterApi.Enum;

/// <summary>
///  災害情報を格納するためのレコード
/// </summary>
public class DisasterInformationEntity{

    /// <summary>
    ///  災害情報種別
    /// </summary>
    public DisasterType Type;

    /// <summary>
    ///  Gps情報を格納する
    /// </summary>
    public string? Gps;

    /// <summary>
    ///  写真をバイナリーデータとして取得する
    /// </summary>
    public byte[]? photo;

    /// <summary>
    /// 住所
    /// </summary>
    public string? address;
}