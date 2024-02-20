using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

TcpChannel channel = new TcpChannel(1234);
ChannelServices.RegisterChannel(channel, false);

RemotingConfiguration.RegisterWellKnownServiceType(
    typeof(RemoteObject),
    "RemoteObject",
    WellKnownObjectMode.Singleton
);

Console.WriteLine("Sunucu başlatıldı. Port: 1234");
Console.ReadLine();


public class RemoteObject : MarshalByRefObject
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}