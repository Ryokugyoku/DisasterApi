using Microsoft.IdentityModel.Tokens;

namespace DisasterAPI.Common;

/// <summary>
///  アップロードされた写真を統合管理するための基底クラス
/// </summary>
public static class PhotoManager{
    
    private static readonly string WorkPath = Directory.GetCurrentDirectory()+"/Photo";
    
    /// <summary>
    ///  ディレクトリがなければ作成を行う
    /// </summary>
    public static void SetUp(){
        if(!Directory.Exists(WorkPath)){
            Directory.CreateDirectory(WorkPath);
        }
    }

    /// <summary>
    ///  写真を保存する
    /// </summary>
    /// <param name="photoBase64"> Base64化された画像</param>
    /// <param name="guid"> 画像名になる値</param>
    /// <param name="PhotoName"> 写真名　拡張子を取得するために利用する</param>
    public static string? SavePhoto(String photoBase64, string guid,string? PhotoName)
    {
        if(photoBase64.IsNullOrEmpty() || PhotoName.IsNullOrEmpty()){
            return null;
        }

        string savePath = WorkPath+"/"+guid+Path.GetExtension(PhotoName);
        byte[] bytes = System.Convert.FromBase64String(photoBase64);
        using(var writer = new BinaryWriter(new FileStream(savePath,FileMode.Create))){
            foreach(byte byt in bytes){
                writer.Write(byt);
            }
        }

        return savePath;
    }

}