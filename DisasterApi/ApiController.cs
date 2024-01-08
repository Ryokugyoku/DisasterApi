using Amazon.DynamoDBv2.DataModel;
using DisasterApi.Entity;
using DisasterAPI.DataBase;
using Microsoft.AspNetCore.Mvc;


/// <summary>
///  災害情報を取り扱う基底API群
/// </summary>
[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase{


    private readonly IDynamoDBContext _context;
    /// <summary>
    ///  DynamoDbに接続するための設定
    /// </summary>
    /// <param name="context"></param>
    public ApiController(IDynamoDBContext context){
        _context = context;
    }

    // /// <summary>
    // ///     蓄積された災害情報を返す
    // ///     ※返すデータはインスタンスごとに同じものを返すため、オンメモリ上でデータを保持してメンテナンスする形にする
    // /// </summary>
    // /// <returns> 災害情報が格納された　Jsonデータを返す</returns>
    // [HttpGet]
    // public string GetDisasterData(){
    //    return "";
    // }

    /// <summary>
    ///     災害情報登録用API
    /// </summary>
    /// <param name="disasterRequest">災害情報格納用モデル</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SetDisasterData(DisasterInformationEntity disasterRequest){
        string ipv4 = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        string ipv6 = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
        var record = DataBaseManager.DisasterInformationEntityToDisasterRecord(disasterRequest, ipv4, ipv6);
        await _context.SaveAsync(record);
        return Ok(disasterRequest);
    }
    
}