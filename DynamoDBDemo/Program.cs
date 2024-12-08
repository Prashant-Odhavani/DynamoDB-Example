using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using DynamoDBDemo.Repositories;
using DynamoDBDemo.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.KeyName));

var credential = new BasicAWSCredentials(builder.Configuration.GetSection("AWSCredential:AccesskeyID").Value, builder.Configuration.GetSection("AWSCredential:Secretaccesskey").Value);
var config = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.USEast1
};

var client = new AmazonDynamoDBClient(credential, config);

builder.Services.AddSingleton<IAmazonDynamoDB>(client);
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

//builder.Services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(RegionEndpoint.USEast1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
