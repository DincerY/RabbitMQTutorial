using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

channel.ExchangeDeclare("deneme_topic", ExchangeType.Topic);

var queueName = channel.QueueDeclare().QueueName;

var bindingKey = args[0] ?? "anonymous";

channel.QueueBind(queue: queueName,
    exchange: "deneme_topic",
    routingKey: bindingKey);


var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
    Console.WriteLine($"Mesaj : {message} , RoutingKey : {ea.RoutingKey}");
};


channel.BasicConsume(queueName,
    autoAck: true,
    consumer: consumer);


Console.WriteLine("Mesaj bekleniyor");
Console.ReadLine();















