import serial
import json
import time
import pymongo

myclient = pymongo.MongoClient("mongodb://localhost:27017/")

mqttIp = None
mqttPort = None
bluetoothCOM = None

bluetoothCOM = input("Bluetooth COM (e.g. COM7): ")
if(bluetoothCOM == None or bluetoothCOM  == ''): bluetoothCOM  = 'COM7'
print(f'\n-------\nCONFIGURATION\n-------\nIP: {mqttIp}\nPORT: {mqttPort}\nBT COM: {bluetoothCOM}')


print("Connecting to serial: " + bluetoothCOM)
time.sleep(1)
try:
    ser = serial.Serial(bluetoothCOM, 9600)
    print("Bluetooth COM opened")
except:
    print("Error opening serial port!\nExiting...")
    exit(1)

while True:
    
    cc=str(ser.readline())
    #cc = cc[6:][:-3]
    firstSplitIndex = cc.find('{')
    secondSplitIndex = cc.rfind('}')
    cc = cc[firstSplitIndex: secondSplitIndex+1]
   
    try:
        jDict = json.loads(cc)
        #print(jDict)
        groupName = list(jDict.keys())[0]
        deviceId = list(jDict[groupName])[0]
        #print(f'DeviceID: {deviceId} -> {jDict[deviceId]}')
    
        mydb = myclient[groupName]
        mycollection = mydb[deviceId]

        dbDict = dict({})
        for key, val in jDict[groupName][deviceId].items():
            dbDict[key] = val

        ret = mycollection.insert_one(dbDict)
        print("Inserted successfully")
            
    except:
        print("Failed to decode: ")
        print(cc)
   

ser.close()










