using Confluent.Kafka;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using System.Text.Json;

namespace MqsCleanArchitectureMVP.Infra.Messaging
{
    public class KafkaProducer : IEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public KafkaProducer(string bootstrapServers, string topic)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
            _topic = topic;
        }

        public async Task PublishAsync<T>(T @event) where T : class
        {
            var message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(@event)
            };
            await _producer.ProduceAsync(_topic, message);
        }
    }
}
