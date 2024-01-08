using System.Reflection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using DisasterAPI.Common;
using DisasterAPI.DataBase;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen( options => {    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
);

var awsOption = builder.Configuration.GetAWSOptions();

builder.Services.AddDefaultAWSOptions(awsOption);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

Amazon.AWSConfigs.AWSProfileName = "local";
//各種セットアップ処理
PhotoManager.SetUp();
DataBaseManager.SetUp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapSwagger().RequireAuthorization();
//コントローラークラスを読み込むためのメソッド
app.MapControllers();

app.UseHttpsRedirection();

app.Run();


