<h1>Simple HTTP Server</h1>
A simple HTTP server designed for the course 4ID3 - IoT Devices and Networks. <br /> <br /> Last updated: <b>2023 - 01 - 26 </b>

<h2>What is an HTTP server?</h2>
Devices access HTTP servers by sending a payload of encoded data to the ip address and port that the server is located at. This data is then read by the server and used. Lastly, data is returned to the sender to confirm that it has received the data, and return the information that the device wants.

<h2> What is a server route? </h2>
An HTTP server can have multiple functions. It could update a database, publish to MQTT, return sensor data, and much, much, more! The way to separate each of these server functions is using something called a 'route'. <br />
<br />
Routes are accessed using the following address: <br />
ip_address:port/<b>route</b>
<br />
<br />
For example, if an MQTT route is created, a device could send data to <b>ip_address:port/mqtt</b> to access that function.

<h2>What is a GET and POST request?</h2>
GET and POST requests are the <b>communication format</b> that devices use to communicate with a server route. If the route is set up as a GET request, make sure you communicate with it using the GET communication format or the server will not understand what to do with the data that you are sending!

<h2>How does the MQTT route in this server work?</h2>
The MQTT route works by having the IoT device provide it with a JSON object. This JSON object is then read. The <b>Group#</b> and <b>DeviceId</b> are separated from the data, and form the <b>MQTT path</b>. Each <b>attribute</b> within the deviceId curly braces is then parsed and transmitted accordingly, on that path.
<br /> <br />
e.g. <br />
{   "GroupA": {  "DeviceA": {   "Temp": "21", "Hum": "2" }  }   }
<br /> <br />
To MQTT as:
<br />
- GroupA/DeviceA/Temp -> 21 <br />
- GroupA/DeviceA/Hum -> 2
<br /><br /><br />

<h2>How does the MongoDB route in this server work?</h2>
The MongoDB route inserts the data into the local mongodb database as provided by the IoT device. It expects the following format:
<br /><br />
e.g. <br />
{   "GroupA": {  "DeviceA": {   "Temp": "21", "Hum": "2" }  }   }
<br /> <br />




