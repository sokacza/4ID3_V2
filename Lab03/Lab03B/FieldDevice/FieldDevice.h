//Libraries
#include <Arduino.h>
#include <Wire.h>
#include <AsyncAPDS9306.h>
#include "EBYTE.h"
#include <HardwareSerial.h>

//Pin definitions 
#define PIN_RX 16   
#define PIN_TX 17   
#define PIN_M0 27  
#define PIN_M1 26   
#define PIN_AX 25  

//Sample frequency
#define DELAY_BETWEEN_SAMPLES_MS 5000

//Transceiver setup
#define TRANSCEIVER_CHANNEL 42
EBYTE Transceiver(&Serial2, PIN_M0, PIN_M1, PIN_AX);

//Device information
String groupName = "GroupA";
String deviceName = "DeviceA";

//Sensor IIC addresses
#define ADDR (byte)(0x40)
#define TMP_CMD (byte)(0xF3)

//Instantiating sensor object and configuration
AsyncAPDS9306 lightSensor;
const APDS9306_ALS_GAIN_t aGain = APDS9306_ALS_GAIN_1;
const APDS9306_ALS_MEAS_RES_t aTime = APDS9306_ALS_MEAS_RES_16BIT_25MS;
