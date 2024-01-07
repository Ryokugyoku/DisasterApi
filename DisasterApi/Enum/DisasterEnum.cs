namespace DisasterApi.Enum;

/// <summary>
/// 　災害状況を表す
/// 　対応表は下記の通り
/// 　
///  0 : 道路陥没
///  1：建造物の倒壊
///  2 : 洪水
///  3 : 停電
///  4 : 断水
/// </summary>
public enum DisasterType{
    /// <summary>
    ///  道路陥没
    /// </summary>
    RoadCollapse = 0,

    /// <summary>
    ///  建造物の倒潰
    /// </summary>
    BuildingCollapse = 1,

    /// <summary>
    ///  洪水
    /// </summary>
    flood = 2,

    /// <summary>
    /// 停電
    /// </summary>
    PowerOutage = 3,

    /// <summary>
    /// 断水
    /// </summary>
    WaterOutage = 4
    
}