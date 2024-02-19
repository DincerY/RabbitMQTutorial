using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory factory = new() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

channel.ExchangeDeclare("deneme", type: ExchangeType.Direct);

var queueName = channel.QueueDeclare().QueueName;

//buradaki routing key publish kısımındakinde biraz farklı bunun adına binding key demek karmaşıklığı önleyecektir.
channel.QueueBind(queue: queueName,
    exchange: "deneme",
    routingKey: "dd");


var consumer = new EventingBasicConsumer(channel);
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














