using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase{

    /// <summary>
    ///     蓄積された災害情報を返す
    ///     ※返すデータはインスタンスごとに同じものを返すため、オンメモリ上でデータを保持してメンテナンスする形にする
    /// </summary>
    /// <returns> 災害情報が格納された　Jsonデータを返す</returns>
    [HttpGet]
    public string GetDisasterData(){
       return "";
    }

    /// <summary>
    ///   災害情報を登録する
    /// </summary>
    /// <param name="json"></param>
    /// <returns> 実行結果を格納するJson</returns>
    [HttpGet]
    public string SetDisasterData(string json){
        return "";
    }
    
}