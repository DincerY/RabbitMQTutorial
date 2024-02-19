using System.Text;
using RabbitMQ.Client;

ConnectionFactory factory = new() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel  = connection.CreateModel();



channel.ExchangeDeclare("deneme", type: ExchangeType.Direct);

var message = Console.ReadLine() ?? "boş mesaj";
if (message == "")
{
    message = "boş mesaj";
}

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange:"deneme",
    routingKey: "dd",
    basicProperties: null,
    body: body);















