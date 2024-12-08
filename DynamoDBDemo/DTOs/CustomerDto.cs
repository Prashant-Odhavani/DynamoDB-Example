using System.Text.Json.Serialization;

namespace DynamoDBDemo.DTOs;

public class Customer
{
    //[JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    //[JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    //[JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    //[JsonPropertyName("birthDay")]
    public DateTime BirthDay { get; set; }
}

