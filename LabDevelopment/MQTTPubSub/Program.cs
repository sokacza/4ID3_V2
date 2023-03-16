using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Protocol;

public partial class Program{
    static async Task Main(string [] args){
        var mqttFactory = new MqttFactory();
        IMqttClient client = mqttFactory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString())
                        .WithTcpServer("test.mosquitto.org", 1883)
                        .WithCleanSession()
                        .Build();
        
         await client.ConnectAsync(options, CancellationToken.None);

        Console.WriteLine("Press 'a' key to publish message");
        Console.ReadLine();

        await PublishMessageAsync(client);
        await client.DisconnectAsync();

        Console.WriteLine("Hello world");
    }

    private static async Task PublishMessageAsync(IMqttClient client){
        string payload = "Hello!";
        var message = new MqttApplicationMessageBuilder()
                            .WithTopic("orange")
                            .WithPayload(payload)
                            .Build();
        
        if(client.IsConnected){
            await client.PublishAsync(message, CancellationToken.None);
        }
    }

}

