import serial
import json
import paho.mqtt.client as mqtt
import time
mqttIp = None
mqttPort = None
bluetoothCOM = None


mqttIp = input("MQTT Broker IP: ")
if(mqttIp == None or mqttIp == ''): mqttIp = 'test.mosquitto.org'

mqttPort = input("MQTT Broker Port: ")
if(mqttPort == None or mqttPort== ''): mqttPort = 1883

bluetoothCOM = input("Bluetooth COM (e.g. COM7): ")
if(bluetoothCOM == None or bluetoothCOM  == ''): bluetoothCOM  = 'COM7'

print(f'\n-------\nCONFIGURATION\n-------\nIP: {mqttIp}\nPORT: {mqttPort}\nBT COM: {bluetoothCOM}')

def on_connect(client, userdata, flags, rc):
    print("Connected to  "+str(rc))

def on_message(client, userdata, msg):
    print(msg.topic+" "+str(msg.payload))

client = mqtt.Client()
client.on_connect = on_connect
client.on_message = on_message
print("Connecting to MQTT")
for x in range(7):
    print(".")
    time.sleep(0.7)
client.connect(mqttIp, mqttPort, 60)

print("Connecting to serial: " + bluetoothCOM)
time.sleep(1)
try:
    ser = serial.Serial(bluetoothCOM, 9600)
    print("Bluetooth COM opened: ", ser)
except:
    exit(1)

while True:
    client.loop()
    cc=str(ser.readline())
    #cc = cc[6:][:-3]
    firstSplitIndex = cc.find('{')
    secondSplitIndex = cc.rfind('}')
    cc = cc[firstSplitIndex: secondSplitIndex+1]
    #print(cc)

   
    try:
        jDict = json.loads(cc)
        #print(jDict)
        groupName = list(jDict.keys())[0]
        #print(groupName)
        deviceId = list(jDict[groupName])[0]
        #print(deviceId)
        print(f'DeviceID: {deviceId} -> {jDict[groupName][deviceId]}')
        for key, val in jDict[groupName][deviceId].items():
            print(f'{groupName}/{deviceId}/{key} -> {val}')
            client.publish(f'{groupName}/{deviceId}/{key}', val.encode("UTF-8"))
            #client.wait_for_publish()
            
    except:
        print("Failed to decode: ")
        print(cc)
   
client.loop_forever()    
ser.close()