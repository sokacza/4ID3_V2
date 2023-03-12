# Lab03\_Bluetooth



4ID3 - IoT Devices and Networks

Lab 3

Communicating Sensor Data over a Bluetooth Network

Adam Sokacz, Ishwar Singh, and Salman Bawa

Sponsored by [_Future Skills Center, Canada_](https://fsc-ccf.ca/) and __ [_McMaster W Booth SEPT_](https://www.eng.mcmaster.ca/sept)

Group Number:

Name, Student Number:

Name, Student Number:

Name, Student Number:

Submission Date:

### Objective

In this lab, sensor data will be read, encoded, and transmitted to a nearby PC using the IoT access technology Bluetooth Classic. This data will then be parsed and routed to both a public MQTT server for use in NodeRED, and a locally run MongoDB database for data storage and analysis.

Contents

[Objective](broken-reference)

[Feedback](broken-reference)

[Additional Resources](broken-reference)

[Pre-Lab Questions](broken-reference)

[Post-Lab Questions](broken-reference)

[Exercise A Results:](broken-reference)

[_Optional:_ Exercise B Results:](broken-reference)

[Setting up the Workspace](broken-reference)

[Reading Sensor Data](broken-reference)

[Transmitting Over Bluetooth](broken-reference)

[Viewing a Bluetooth Serial Device](broken-reference)

[Exercise A](broken-reference)

[Parsing Data using Python](broken-reference)

[Installing Python](broken-reference)

[Installing VSCode](broken-reference)

[MQTT Routing](broken-reference)

[Verify MQTT](broken-reference)

[Exercise B](broken-reference)

[Exiting the Python Application](broken-reference)

[_Optional:_ Connecting to a Database](broken-reference)

[Exercise C](broken-reference)

[Pushing Changes to GitHub](broken-reference)

\


### Feedback

Q1 - What would you rate the difficulty of this lab?

_(1 = easy, 5 = difficult)_

| 1 | 2 | 3 | 4 | 5 |
| - | - | - | - | - |

Comments about the difficulty of the lab:

Q2 - Did you have enough time to complete the lab within the designated lab time?

Q3 - How easy were the lab instructions to understand?

_(1 = easy, 5 = unclear)_

| 1 | 2 | 3 | 4 | 5 |
| - | - | - | - | - |

List any unclear steps:

Q4 - Could you see yourself using the skills learned in this lab to tackle future engineering challenges?

_(1 = no, 5 = yes)_

| 1 | 2 | 3 | 4 | 5 |
| - | - | - | - | - |

### &#x20;

### Additional Resources

Lab GitHub Repo ( [https://github.com/sokacza/4ID3](https://github.com/sokacza/4ID3) )

Arduino Programming Refresher ( [https://youtu.be/CbJHL\_P5RJ8](https://youtu.be/CbJHL\_P5RJ8) )

Mosquitto MQTT Broker Tutorial ( [https://youtu.be/DH-VSAACtBk](https://youtu.be/DH-VSAACtBk) )

NodeRED Fundamentals Tutorial ( [https://youtu.be/3AR432bguOY](https://youtu.be/3AR432bguOY) )

ESP32 Overview ( [https://youtu.be/UuxBfKA3U5M](https://youtu.be/UuxBfKA3U5M) )

### Pre-Lab Questions

Q1 - In your own words, describe the master-slave messaging pattern. What role does the master device play? What role do the slave devices play? How many slave devices can be coordinated by a single master device?

Q2 - Compare and contrast Bluetooth Classic vs BLE. What are advantages and drawbacks of each technology?

Q3 - What layer of the OSI model does Bluetooth technology reside in?

Q4 - What is a network gateway? What characteristics must the device have to be considered a gateway device?

### Post-Lab Questions

Q1 - What network topology would best describe the IoT network built in this lab? Explain with a diagram.

Q2 - If the microcontroller is transmitting data to the PC, but the Python script is not running, how does this impact what data is accessible through MQTT?

Q3 - What is the theoretical range of Bluetooth Classic? How might this impact its use in IoT networks?

Q4 - What is a relational database? What is a non-relational database? How do they differ? What type of database is MongoDB?

Q5 - List 3 security concerns of this Bluetooth network. How might these concerns be mitigated?

Q6 - Write a brief LinkedIn post about key learning takeaways from this lab.

### Exercise A Results:

### Exercise B Results:

### _Optional:_ Exercise C Results: 

### Setting up the Workspace <a href="#_toc125068005" id="_toc125068005"></a>

Each lab, we will be creating a new folder in the local git repository that was created in the provided pre-lab to store and document technologies that you have worked on.

Navigate to your local git repository for this course.





Create a new folder named Lab02. Navigate inside this folder.



Create a new text file in the folder.



Press File > Save as.



Save it as Lab02.md. Ensure that the Save as type is set to All files (\*.\*).



Now, you should have two files, a text file and a markdown file. Delete the text file.





To open the markdown file, right-click and select Open with. Choose Notepad.



Writing markdown documents to explain your code is very similar to HTML. A reference guide can be found here:

[https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)

Write the following text in the markdown file and save it.



_\<h1> 4ID3 Lab 02 - Bluetooth Communication\</h1>_

_\<h2>2023 - 01 - 24\</h2>_

_In this lab, we explored using the BluetoothSerial library to_

_communicate sensor data from an ESP32 microcontroller to a PC._

_The data was formatted as a JSON string and parsed by a Python_

_application on the PC. The data was then either published over_

_MQTT or inserted into a local MongoDB database for further analysis._

Save the file.

Navigate to the root folder (_4ID3/, root main highest-level folder_) of your local repository.



Right-click in the root folder of your local repository and launch git bash.



First, we need to add all the changes to the index that will be synced with GitHub. This will be done with the git add command.



_git add ._

The period �.� Is used as a shorthand for selecting all changes.

Next, when we are happy with the changes we chose to upload, we can use the commit command to package them to be synced.



_��������������� git commit -m �Lab 2 folder�_

The �-m� flag stands for message, and it adds a message that explains what changes were made.

Lastly, to sync your local git repository with GitHub, use the git push command.



_git push origin main_

Now, log into GitHub and verify that the changes have been made.



Now, if you are collaborating and wish to sync your local git repo with the remote GitHub repo, use the git pull command. In this case, we see that our local git repo is already up-to-date.



\


### Reading Sensor Data

The goal of this section of the lab is to read data from 2 sensors and print them to the serial monitor, before we communicate to a server.

Launch the Arduino IDE and Save as into your lab 2 folder.



The 2 sensors we will be using are as follows:

�         APDS9306 for Light Intensity

�         Si7020-A20 for Temperature

The APDS9306 library must be downloaded from GitHub. Navigate to the following link:

[https://github.com/gmarti/AsyncAPDS9306](https://github.com/gmarti/AsyncAPDS9306)



Press Code > Download Zip.



Navigate back to the Arduino IDE.

Navigate to Sketch > Include Library > Add .ZIP Library.



Find and open the downloaded library.



Create a new header file. Name this file Lab02.h.





In this file, we will keep our dependencies, preprocessor macros, global variables, and global objects.



Lastly, lets instantiate some global objects for classes that we will be using throughout the code.

This concludes the header file. Let�s move back to the implementation file.

Firstly, include our header file.



Next, set up the void setup() function.



Moving onto the void loop() function, it should be noticed that both the Temperature and Light Intensity sensors are being polled in different ways.



To upload to the board, change the board to ESP32 Dev Module.



Leave the default communication settings the same, with the exception of the COM port. Select the COM port that your microcontroller is connected to.



Uploading to the MacIoT board can be somewhat unintuitive. Follow the following steps:

1 - Hold down both the FLASH and RESET buttons



2 - After 2 seconds, release the RESET button. Continue to hold the FLASH button



3 - Once the code finishes compiling and begins to upload, release the FLASH button.





A successful upload should look like this:



After the upload is complete (NOT DURING), launch the Serial monitor to view the microcontroller output.





### Transmitting Over Bluetooth

Navigate back to your Lab02 folder. Copy Lab02A and rename it� to Lab02B.





Rename the constituent files.





Open the project in Arduino IDE.

Rename the header file import to match the new name.



Modify the header file to include the built-in BluetoothSerial library. Instantiate a serial object for use in the implementation file.



In the setup() function of the implementation file, use the begin() method of the SerialBT object to initialize the Bluetooth link.



In the loop() function of the implementation file, concatenate a JSON object with your desired data. This JSON String is then interpreted as a C-style character array and pushed into the Bluetooth output buffer one element at a time.



Upload the modified project to your MacIoT board.

Open Serial Monitor and observe the serial output.



### �

### Viewing a Bluetooth Serial Device

Navigate to the following URL and install MobaXTerm Home Edition.

[https://mobaxterm.mobatek.net/download-home-edition.html](https://mobaxterm.mobatek.net/download-home-edition.html)

Choose the Installer Edition.



A ZIP file will be downloaded. This file must be extracted and the MSI installer must be ran as Administrator.





Install using the default options.



Launch MobaXTerm.



MobaXTerm is a feature filled application that is used to manage servers and ports. We will be using it to open the Bluetooth serial port and ensure that data is being transmitted between the MacIoT board and our PC.

Before proceeding, enable Bluetooth on your PC and connect to the microcontroller.



Toggle Bluetooth On and press Add device.



Choose Bluetooth.



Press on your microcontroller to connect.



Navigate back to MobaXTerm and press Session.

Select Serial from the top ribbon.

Choose a Bluetooth serial port. You may need to try all that are available to find which one is transmitting.



In my case, this ended up being COM10 at 9600 baud.



### Exercise A

Modify the MacIoT code so that Humidity is read from the sensor, formatted as a JSON attribute, and transmitted to MQTT.

_NOTE: The Python routing script will automatically parse the new parameter_.

_IIC Humidity Command = 0xF5_

_IIC Humidity Address = 0x40 (same as temp)_

_What is JSON?:_ [_https://www.w3schools.com/js/js\_json\_syntax.asp_](https://www.w3schools.com/js/js\_json\_syntax.asp)

### Parsing Data using Python

It may not be enough to view the data. We want to be able to act on the data being sent, collect it over time, and visualize it on an HMI or familiar format.

### Installing Python

Navigate to the following website and install the latest version of Python 3.

[https://www.python.org/downloads/](https://www.python.org/downloads/)



Install using the default options. If there is a checkbox to Add to Path, please check this checkbox.







Once Python is installed, please restart your computer.

### Installing VSCode

Navigate to the following URL:

[https://code.visualstudio.com/download](https://code.visualstudio.com/download)



Run the installer using the default install options.

Once installed launch VSCode.

Open the Extensions tab using the ribbon on the left-side.



Search for Python and Install the one provided by Microsoft.

Within the Lab02 folder, create a new folder named Scripts.





Within VSCode, do File > Open Folder.



Open your local repository.



You should be able to see your Scripts/ folder in the File Explorer on the left-tab of your VSCode Editor.



### MQTT Routing

The first script that we will write will parse the JSON string with our smart device data and route it to its appropriate MQTT path.

Right-click and select New File.



Name it btserial2mqtt.py.



Double-click to open it in the text editor.



Copy out the following python script:

_import serial_

_import json_

_import paho.mqtt.client as mqtt_

_import time_

_mqttIp = None_

_mqttPort = None_

_bluetoothCOM = None_

_mqttIp = input("MQTT Broker IP: ")_

_if(mqttIp == None or mqttIp == ''): mqttIp = 'test.mosquitto.org'_

_mqttPort = input("MQTT Broker Port: ")_

_if(mqttPort == None or mqttPort== ''): mqttPort = 1883_

_bluetoothCOM = input("Bluetooth COM (e.g. COM7): ")_

_if(bluetoothCOM == None or bluetoothCOM� == ''): bluetoothCOM� = 'COM7'_

_print(f'\n-------\nCONFIGURATION\n-------\nIP: {mqttIp}\nPORT: {mqttPort}\nBT COM: {bluetoothCOM}')_

_def on\_connect(client, userdata, flags, rc):_

_��� print("Connected to� "+str(rc))_

_def on\_message(client, userdata, msg):_

_��� print(msg.topic+" "+str(msg.payload))_

_client = mqtt.Client()_

_client.on\_connect = on\_connect_

_client.on\_message = on\_message_

_print("Connecting to MQTT")_

_for x in range(7):_

_��� print(".")_

_��� time.sleep(0.7)_

_client.connect(mqttIp, mqttPort, 60)_

_print("Connecting to serial: " + bluetoothCOM)_

_time.sleep(1)_

_try:_

_��� ser = serial.Serial(bluetoothCOM, 9600)_

_��� print("Bluetooth COM opened")_

_except:_

_��� exit(1)_

_while True:_

_��� client.loop()_

_��� cc=str(ser.readline())_

_��� #cc = cc\[6:]\[:-3]_

_��� firstSplitIndex = cc.find('{')_

_��� secondSplitIndex = cc.rfind('}')_

_��� cc = cc\[firstSplitIndex: secondSplitIndex+1]_

_��� #print(cc)_

_��_

_��� try:_

_������� jDict = json.loads(cc)_

_������� #print(jDict)_

_������� groupName = list(jDict.keys())\[0]_

_������� #print(groupName)_

_������� deviceId = list(jDict\[groupName])\[0]_

_������� #print(deviceId)_

_������� print(f'DeviceID: {deviceId} -> {jDict\[groupName]\[deviceId]}')_

_������� for key, val in jDict\[groupName]\[deviceId].items():_

_����������� print(f'{groupName}/{deviceId}/{key} -> {val}')_

_����������� client.publish(f'{groupName}/{deviceId}/{key}', val.encode("UTF-8"))_

_����������� #client.wait\_for\_publish()_

_�����������_

_��� except:_

_������� print("Failed to decode: ")_

_������� print(cc)_

_��_

_client.loop\_forever()���_

_ser.close()_

For the above script to work, we must install 2 libraries.

Open Powershell as Administrator.



Run the following two commands:

��� _pip install pyserial_

_��� pip install paho-mqtt_



Within VSCode, navigate to Terminal > New Terminal.



A new Powershell terminal window will open inside VSCode.

Navigate to your Lab02/Scripts/ directory.



To launch the python application, run the following command:

��� _python ./btserial2mqtt.py_



Fill in the prompted information. Press enter to use test.mosquitto.org defaults.

Ensure that your MacIoT board is still transmitting. Press RESET to restart it. Wait 10 seconds.

ENSURE THAT NO OTHER BLUETOOTH SERIAL MONITORS ARE OPEN, BLOCKING THE PORT.

Run btserial2mqtt.py using the following command:

��� _Python ./btserial2mqttt.py_





### Verify MQTT

Use the MQTT application on your phone or the Mosquitto MQTT client installed previously to verify that data is being transmitted to the correct paths.

�



### Exercise B

Now that data is being transmitted to MQTT, using knowledge from previous labs, set up a NodeRED flow to read this data from the public MQTT broker and visualize it.

### Exiting the Python Application

Press CTRL + C to exit the Python application.



### _Optional:_ Connecting to a Database

Navigate to the following URL and download MongoDB Community.

[https://www.mongodb.com/try/download/community-kubernetes-operator](https://www.mongodb.com/try/download/community-kubernetes-operator)



Run the installer using default settings. It will say This may contain malicious software. Ignore this warning, this software is very reputable, the packaging format is just out-of-date.



Perform a Complete installation.



Leave Service Configuration as default.



Ensure that Install MongoDB Compass is checked.





Launch MongoDB Compass.





Press Connect.



Navigate back to VSCode and create a new Python script in the Scripts/ folder named btserial2mongodb.



Using Powershell as Administrator, install the following dependencies using pip package manager.

��� _pip install pyserial_

_��� pip install pymongo_



Paste the following Python script into the blank python file:

_import serial_

_import json_

_import time_

_import pymongo_

_myclient = pymongo.MongoClient("mongodb://localhost:27017/")_

_bluetoothCOM = None_

_bluetoothCOM = input("Bluetooth COM (e.g. COM7): ")_

_if(bluetoothCOM == None or bluetoothCOM� == ''): bluetoothCOM� = 'COM7'_

_print(f'\n-------\nCONFIGURATION\n-------\nIP: {mqttIp}\nPORT: {mqttPort}\nBT COM: {bluetoothCOM}')_

_print("Connecting to serial: " + bluetoothCOM)_

_time.sleep(1)_

_try:_

_��� ser = serial.Serial(bluetoothCOM, 9600)_

_��� print("Bluetooth COM opened")_

_except:_

_��� exit(1)_

_while True:_

_���_

_��� cc=str(ser.readline())_

_��� #cc = cc\[6:]\[:-3]_

_��� firstSplitIndex = cc.find('{')_

_��� secondSplitIndex = cc.rfind('}')_

_��� cc = cc\[firstSplitIndex: secondSplitIndex+1]_

_��_

_��� try:_

_������� jDict = json.loads(cc)_

_������� #print(jDict)_

_������� groupName = list(jDict.keys())\[0]_

_������� deviceId = list(jDict\[groupName])\[0]_

_������� #print(f'DeviceID: {deviceId} -> {jDict\[deviceId]}')_

_���_

_������� mydb = myclient\[groupName]_

_������� mycollection = mydb\[deviceId]_

_������� dbDict = dict({})_

_������� for key, val in jDict\[groupName]\[deviceId].items():_

_����������� dbDict\[key] = val_

_������� ret = mycollection.insert\_one(dbDict)_

_������� print("Inserted successfully")_

_�����������_

_��� except:_

_������� print("Failed to decode: ")_

_������� print(cc)_

_��_

_ser.close()_



Run the python program while the MacIoT board is connected with Bluetooth and transmitting data.





If the data is being parsed correctly and it can access the MongoDB database, then Inserted Successfully should be printed.

Reload your MongoDB Compass client:



Observe that a new database has been generated. Open this database.



You should see all of your data being inserted.



### _Optional:_ Exercise C

Collect sensor data for 2 minutes then export the dataset from the database. Using excel or another spreadsheet software, graph the data and identify temperature and light intensity trends. Include the graphs with your lab submission.

### Pushing Changes to GitHub

Open git bash in your local repository.



Add and commit your changes.



Push your changes.



Check that they�ve been synced correctly.

