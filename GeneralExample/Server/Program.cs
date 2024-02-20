using System.Text;
using RabbitMQ.Client;

Console.Write("Yayınlanacak mesajı giriniz : ");
var message = Console.ReadLine() ?? "Boş mesaj gönderildi";
var messageByte = Encoding.UTF8.GetBytes(message);


ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

channel.ExchangeDeclare("deneme_topic", ExchangeType.Topic);


var routingKey = args[0] ?? "anonymous";


channel.BasicPublish(exchange: "deneme_topic",
    routingKey: routingKey,
    basicProperties: null,
    body: messageByte);


