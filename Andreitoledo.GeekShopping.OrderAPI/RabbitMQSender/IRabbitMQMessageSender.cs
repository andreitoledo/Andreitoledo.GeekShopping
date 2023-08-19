using Andreitoledo.GeekShopping.MessageBus;

namespace Andreitoledo.GeekShopping.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
