using N5.Permissions.BL.Models;

namespace N5.Permissions.BL.Messaging;

public interface IKafkaProducerService
{
    Task ProduceMessageAsync(string topic, string operationName, PermissionDto message);
}
