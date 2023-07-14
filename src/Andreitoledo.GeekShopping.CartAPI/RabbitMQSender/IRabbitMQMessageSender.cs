using Andreitoledo.GeekShopping.MessageBus;

namespace Andreitoledo.GeekShopping.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
