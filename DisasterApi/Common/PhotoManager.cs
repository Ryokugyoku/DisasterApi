namespace DisasterAPI.Common;

/// <summary>
///  アップロードされた写真を統合管理するための基底クラス
/// </summary>
public static class PhotoManager{
    
    /// <summary>
    ///  ディレクトリがなければ作成を行う
    /// </summary>
    public static void SetUp(){
        string workPath = Directory.GetCurrentDirectory();
        workPath += "/Photo";
        if(!Directory.Exists(workPath)){
            Directory.CreateDirectory(workPath);
        }
    }

    /// <summary>
    ///  写真を保存する
    /// </summary>
    /// <param name="photoBase64"></param>
    public static void SavePhoto(String photoBase64){

    }
}