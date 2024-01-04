using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//DB接続サンプルコードローカル用のDynamoDb構築予定
// // 認証情報を設定します。
// var credentials = new BasicAWSCredentials("access_key", "secret_key");
// var config = new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.APNortheast1 };
// var client = new AmazonDynamoDBClient(credentials, config);
// // DynamoDB に接続します。
// var context = new DynamoDBContext(client);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger().RequireAuthorization();
//コントローラークラスを読み込むためのメソッド
app.MapControllers();

app.UseHttpsRedirection();

app.Run();


