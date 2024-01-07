using DisasterApi.Entity;
using DisasterAPI.DataBase.Models;

namespace DisasterAPI.DataBase;

/// <summary>
///  DynamoDBのCrud処理に必要なコード群が記載されている
/// </summary>
public static class DataBaseManager{

    /// <summary>
    /// 　DisasterInformationEntity からDisasterTableを生成する
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static DisasterTable DisasterInformationEntityToDisasterRecord(DisasterInformationEntity entity){
        DisasterTable record = new ();
        return record;
    }
}