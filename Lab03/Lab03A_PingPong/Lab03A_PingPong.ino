#include "Lab03A.h"

void setup() {

  Serial.begin(9600);
  Serial2.begin(9600);

  Transceiver.init();
  //Transceiver.SetAirDataRate(AIR_DATA_RATE);
  Transceiver.SetChannel(TRANSCEIVER_CHANNEL);
  //Transceiver.SetMode(MODE_NORMAL);
  //Transceiver.SetTransmitPower(OPT_TP20);
  //Transceiver.SaveParameters(PERMANENT);
  Transceiver.PrintParameters();
}


unsigned long startTime = millis();

void loop() {
  
  if (Serial2.available() > 1) {
    Serial.println("Receving Data...");
    String incomingData = Serial2.readString();
    Serial.println("PING: " + incomingData);

  }

  if(millis() - startTime > TIME_PER_SEND_MS){
    Serial2.println(GROUP_NAME + " - " + DEVICE_ID);
    Serial.println("PONG SENT");
    startTime = millis();
  }

}
