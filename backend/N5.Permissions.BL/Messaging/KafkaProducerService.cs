using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using N5.Permissions.BL.Models;
using System.Text.Json;

namespace N5.Permissions.BL.Messaging;

public class KafkaProducerService : IKafkaProducerService
{
    private readonly string _bootstrapServers;

    public KafkaProducerService(IConfiguration configuration)
    {
        _bootstrapServers = configuration["Kafka:BootstrapServers"];
    }

    public async Task ProduceMessageAsync(string topic, string operationName, PermissionDto message)
    {
        var config = new ProducerConfig { BootstrapServers = _bootstrapServers };
        using var producer = new ProducerBuilder<string, string>(config).Build();

        var key = Guid.NewGuid().ToString();
        var value = JsonSerializer.Serialize(new
        {
            Id = key,
            Operation = operationName,
            Data = message
        });

        await producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value });
        producer.Flush(TimeSpan.FromSeconds(10));
    }
}
