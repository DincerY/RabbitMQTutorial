using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory factory = new() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

channel.ExchangeDeclare("denemeTopic", ExchangeType.Topic);


var queueName = channel.QueueDeclare().QueueName;

foreach (var bindingKey in args)
{
    channel.QueueBind(queue: queueName,
        exchange: "denemeTopic",
        routingKey: bindingKey);
}

var consumer =new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = ea.RoutingKey;
    Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
};


channel.BasicConsume(queue: queueName,
    autoAck: true,
    consumer: consumer);



Console.ReadLine();






