# MQTT

MQTT stands for MQ Telemetry Transport

It is a lightweight messaging protocol that was initially developed to manage the industrial sensors on oil pipelines across vast distances. It was rapidly adopted into other industries and expanded on, with other libraries such as ZeroMQ and RabbitMQ.

MQTT works by the publish-subscribe messaging pattern. This means that remote sensor publish to different topics (URI) on the central server, called the MQTT broker.&#x20;

For other devices or a client PC to receive the published data, they must subscribe to the same topic. Devices are allowed duplex communication, in which they subscribe and publish to different topics concurrently.&#x20;

<figure><img src="../.gitbook/assets/image (2) (1).png" alt=""><figcaption></figcaption></figure>

When implementing this in code, callback functions are used to handle data being received on any subscribed topics. The following examples identify this clearly:

{% embed url="https://github.com/eclipse/paho.mqtt.python/blob/master/examples/client_sub.py" %}

{% embed url="https://github.com/knolleary/pubsubclient/tree/master/examples" %}

{% tabs %}
{% tab title="Python" %}
Notice how the pre-defined callback functions implemented then set to the appropriate method on the mqttc object. In the on\_message callback function, the msg object contains the message payload and configuration.



```python
def on_connect(mqttc, obj, flags, rc):
    print("rc: " + str(rc))


def on_message(mqttc, obj, msg):
    print(msg.topic + " " + str(msg.qos) + " " + str(msg.payload))


def on_publish(mqttc, obj, mid):
    print("mid: " + str(mid))


def on_subscribe(mqttc, obj, mid, granted_qos):
    print("Subscribed: " + str(mid) + " " + str(granted_qos))


def on_log(mqttc, obj, level, string):
    print(string)

mqttc = mqtt.Client()
mqttc.on_message = on_message
mqttc.on_connect = on_connect
mqttc.on_publish = on_publish
mqttc.on_subscribe = on_subscribe
```
{% endtab %}

{% tab title="C++" %}
To contrast, in C++ a single callback function is defined and if statements must be used to handle specific subscriptions.



```arduino
void callback(char* topic, byte* message, unsigned int length) {
  Serial.print("Message arrived on topic: ");
  Serial.print(topic);
  Serial.print(". Message: ");
  String messageTemp;
  
  for (int i = 0; i < length; i++) {
    Serial.print((char)message[i]);
    messageTemp += (char)message[i];
  }
  Serial.println();

  // Feel free to add more if statements to control more GPIOs with MQTT

  // If a message is received on the topic esp32/output, you check if the message is either "on" or "off". 
  // Changes the output state according to the message
  if (String(topic) == "esp32/output") {
    Serial.print("Changing output to ");
    if(messageTemp == "on"){
      Serial.println("on");
      digitalWrite(ledPin, HIGH);
    }
    else if(messageTemp == "off"){
      Serial.println("off");
      digitalWrite(ledPin, LOW);
    }
  }
}
```



```arduino
const char* ssid = "REPLACE_WITH_YOUR_SSID";
const char* password = "REPLACE_WITH_YOUR_PASSWORD";

// Add your MQTT Broker IP address, example:
//const char* mqtt_server = "192.168.1.144";
const char* mqtt_server = "YOUR_MQTT_BROKER_IP_ADDRESS";

WiFiClient espClient;
PubSubClient client(espClient);

client.setServer(mqtt_server, 1883);
client.setCallback(callback);
```
{% endtab %}
{% endtabs %}

