// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


TcpChannel channel = new TcpChannel();
ChannelServices.RegisterChannel(channel, false);

RemoteObject remoteObject = (RemoteObject)Activator.GetObject(
    typeof(RemoteObject),
    "tcp://localhost:1234/RemoteObject"
);

if (remoteObject != null)
{
    int result = remoteObject.Add(5, 7);
    Console.WriteLine("Uzak yöntem çağrısı sonucu: " + result);
}
else
{
    Console.WriteLine("Uzak nesne alınamadı.");
}

Console.ReadLine();