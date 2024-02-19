using System.Net.Sockets;
using System.Text;
using RabbitMQ.Client;

ConnectionFactory factory = new() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

channel.ExchangeDeclare("denemeTopic", ExchangeType.Topic);

var message = Console.ReadLine();
if (message is null)
{
    message = "boş mesaj";
}
var body = Encoding.UTF8.GetBytes(message);

var routingKey = args[0];



channel.BasicPublish("denemeTopic",
    routingKey: routingKey,
    basicProperties: null,
body:body);

