
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DisasterApi.Entity;
using DisasterAPI.Common;
using DisasterAPI.DataBase.Models;
namespace DisasterAPI.DataBase;

/// <summary>
///  DynamoDBのCrud処理に必要なコード群が記載されている
/// </summary>
public static class DataBaseManager{

    /// <summary>
    ///     DynamoDBのテーブル一覧
    /// </summary>
    public static List<String> TableNameList {get;set;} =new List<string>();

    private static IAmazonDynamoDB  client = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
        {
            ServiceURL = "http://localhost:8000"
        });

    /// <summary>
    ///  DBのマイグレーションを行う
    /// </summary>
    public static async void SetUp(){
        try{
            await GetTableList();
            CreateDisasterTable();
        }catch(Exception e){
            Console.WriteLine(e.StackTrace);
        }
    }

    private static async Task GetTableList()
    {
        string? lastTableNameEvaluated = null;
        do
        {
            var response = await client.ListTablesAsync(new ListTablesRequest
            {
                Limit = 2,
                ExclusiveStartTableName = lastTableNameEvaluated
            });

            foreach (var name in response.TableNames)
            {
                TableNameList.Add(name);
            }

            lastTableNameEvaluated = response.LastEvaluatedTableName;
        } while (lastTableNameEvaluated != null);
    }

    /// <summary>
    ///  DisasterTableを作成するコード
    ///  ここでは、主キーとなる項目や、索引用の項目を宣言するのみ。
    ///  その他普通の項目はテーブル作成後に追記していく形に運用する
    /// </summary>
    private static async void CreateDisasterTable(){
        string tableName = "disaster";

        if(TableNameList.Contains(tableName)){
            return;
        }
            var response = await client.CreateTableAsync(new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                              {
                                  new AttributeDefinition
                                  {
                                      AttributeName = "id",
                                      AttributeType = "S"
                                  },
                                  new AttributeDefinition{
                                    AttributeName = "disaster_type",
                                    AttributeType = "N"
                                  }
                              },
                KeySchema = new List<KeySchemaElement>()
                              {
                                  new KeySchemaElement
                                  {
                                      AttributeName = "id",
                                      KeyType = "HASH"
                                  },
                                  new KeySchemaElement{
                                    AttributeName = "disaster_type",
                                    KeyType = "RANGE"
                                  }
  
                              },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            });
            
            var request = new DescribeTableRequest
            {
                TableName = response.TableDescription.TableName,
            };

            TableStatus status;

            int sleepDuration = 2000;

            do
            {
                System.Threading.Thread.Sleep(sleepDuration);

                var describeTableResponse = await client.DescribeTableAsync(request);
                status = describeTableResponse.Table.TableStatus;

                Console.Write(".");
            }
            while (status != "ACTIVE");
    }


    /// <summary>
    /// DBの登録を行うメソッド
    /// </summary>
    /// <param name="client"></param>
    /// <param name="tableName"></param>
    /// <param name="response"></param>
    private static void WaitTillTableCreated(AmazonDynamoDBClient client, string tableName,
        Task<CreateTableResponse> response)
        {


        }
        
    /// <summary>
    /// 　DisasterInformationEntity からDisasterTableを生成する
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ipv4"> </param>
    /// <param name="ipv6"> </param>
    /// <returns></returns>
    public static DisasterTable DisasterInformationEntityToDisasterRecord(DisasterInformationEntity entity, string ipv4, string ipv6){
        DisasterTable record = new ();

        record.Guid = Guid.NewGuid().ToString("N");
        record.Address = entity.Address;
        record.Gps = entity.Gps;
        record.DisasterType = (int)entity.Type;
        record.Ipv4 = ipv4;
        record.Ipv6 = ipv6;

        record.FilePath = PhotoManager.SavePhoto(entity.PhotoBase64?? "",record.Guid,entity.PhotoName);
    
       
        return record;
    }
}