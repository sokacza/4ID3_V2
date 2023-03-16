using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Protocol;


public partial class Program{

    public static async Task Main(string[] args){
        var mqttFactory = new MqttFactory();
        IMqttClient client = mqttFactory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString())
                        .WithTcpServer("test.mosquitto.org", 1883)
                        .WithCleanSession()
                        .Build();

            await client.ConnectAsync(options, CancellationToken.None);

            var subOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                    f =>
                    {
                        f.WithTopic("orange");
                    })
                .Build();
            
            await client.SubscribeAsync(subOptions);
            
            client.UseApplicationMessageReceivedHandler(e =>
{
    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
    Console.WriteLine();

    Task.Run(() => client.PublishAsync("hello/world"));
});
    //         await client.UseConnectedHandler(async e => {
    //             Console.WriteLine("Connected to broker");
    //             var topicFilter = new TopicFilterBuilder()
    //                                 .WithTopic("orange")
    //                                 .Build();

    //             await client.SubscribeAsync(topicFilter);
    //             client.UseApplicationMessageReceivedHandler(e => {
    //             Console.WriteLine("Received Message : " + Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
    //             });
        
    //         });
    }

}



