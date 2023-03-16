//Libraries
#include <Arduino.h>
#include <Wire.h>
#include <AsyncAPDS9306.h>

//IIC Addresses for Temperature Sensor
#define ADDR (byte)(0x40)
#define TMP_CMD (byte)(0xF3)

//Sample frequency
#define DELAY_BETWEEN_SAMPLES_MS 5000

//Device information
String groupName = "GroupA";
String deviceName = "DeviceA";

//Instantiating sensor object and configuration
AsyncAPDS9306 lightSensor;
const APDS9306_ALS_GAIN_t aGain = APDS9306_ALS_GAIN_1;
const APDS9306_ALS_MEAS_RES_t aTime = APDS9306_ALS_MEAS_RES_16BIT_25MS;
