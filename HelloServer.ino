#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>
#include <WiFiUdp.h>
#include <ArduinoOTA.h>

const char* ssid = "10-KORPUSMG";
const char* password = "10707707";

ESP8266WebServer server(80);

const int led = 13;
const int led1 = 5;
const int analog = A0;
String webhtml1="";

int svetoforing = 0;

void handleRoot() {
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n"; 
//  webhtml1 += "<link rel=icon href=http://justlan.net/favicon.ico type=image/x-icon /> \n";
  webhtml1 += "<title>10 корпус &mdash; Главная</title> \n";
  webhtml1 += "<meta charset=utf-8> \n";  // the connection will be closed after completion of the response
//  webhtml1 += "Refresh: 10 \n";  // refresh the page automatically every 10 sec
  webhtml1 += "<meta http-equiv=refresh content=2> \n";
webhtml1 += "<H1>Управление</H1> \n";
webhtml1 += "<H3>Helloy Nastya</H3> \n";
webhtml1 += "<p><a href=/meteo class=design>Метеостанция</a>";
webhtml1 += "<p><a href=/datsiki class=design>Датчики движения</a>";
webhtml1 += "<p><a href=/setof class=design>Управление светофорами</a>";
webhtml1 += "<H2>Осадки: " + String((int)analogRead(analog)-1) + "</H2>";

  digitalWrite(led, 1);
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
  digitalWrite(led1, 0);
}

void handleNotFound(){
  digitalWrite(led, 1);
  String message = "File Not Found\n\n";
  message += "URI: ";
  message += server.uri();
  message += "\nMethod: ";
  message += (server.method() == HTTP_GET)?"GET":"POST";
  message += "\nArguments: ";
  message += server.args();
  message += "\n";
  for (uint8_t i=0; i<server.args(); i++){
    message += " " + server.argName(i) + ": " + server.arg(i) + "\n";
  }
  server.send(404, "text/html", message);
  digitalWrite(led, 0);
}
void Yesdviz(){
  digitalWrite(led, 1);
  svetoforing = 1;
  server.send(200, "text/html", "<meta charset=utf-8> \n Движение регулируется");
  digitalWrite(led, 0);
}
void Nodviz(){
  digitalWrite(led, 1);
  svetoforing = 0;
  server.send(200, "text/html", "<meta charset=utf-8> \n Движение не регулируется");
  digitalWrite(led, 0);
}
void Dat1(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  webhtml1 += "<meta http-equiv=refresh content=1> \n";
 webhtml1 += "<H1>+ +</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}
void Dat2(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<meta http-equiv=refresh content=1> \n";
 webhtml1 += "<H1>+ +</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}
void Dat3(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<meta http-equiv=refresh content=1> \n";
 webhtml1 += "<H1>+ +</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void metiost(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  webhtml1 += "<meta http-equiv=refresh content=2> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<H1>Метеостанция</H1> \n";
  webhtml1 += "<H3>Осадки: " + String((int)analogRead(analog)-1) + "</H3>";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void datk(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  webhtml1 += "<meta http-equiv=refresh content=2> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<H1>Состояние датчиков движения</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void svetor(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
   if(svetoforing == 1){webhtml1 += "<H3> Светофры включены</H3> \n";} 
   else{webhtml1 += "<H3> Светофры выключены</H3> \n";}
   webhtml1 += "<meta charset=utf-8> \n";
   webhtml1 += "<p><a href=/ondviz class=design>Включить регулирование</a> \n";
   webhtml1 += "<p><a href=/offdviz class=design>Выключить регулирование</a> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void helping(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
 // webhtml1 += "<meta http-equiv=refresh content=2> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<H1>Справка</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void specon(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
 // webhtml1 += "<meta http-equiv=refresh content=2> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<H1>Спецсигналы включены</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void specoff(){
  digitalWrite(led, 1);
  webhtml1 = ""; 
  webhtml1 += "<!DOCTYPE HTML> \n";
  //webhtml1 += "<meta http-equiv=refresh content=2> \n";
  webhtml1 += "<meta charset=utf-8> \n";
  webhtml1 += "<H1>Спецсигналы выключены</H1> \n";
  server.send(200, "text/html", webhtml1);
  digitalWrite(led, 0);
}

void setup(void){
    ArduinoOTA.onStart([]() {
    Serial.println("Start");
  });
  ArduinoOTA.onEnd([]() {
    Serial.println("\nEnd");
  });
  ArduinoOTA.onProgress([](unsigned int progress, unsigned int total) {
    Serial.printf("Progress: %u%%\r", (progress / (total / 100)));
  });
  ArduinoOTA.onError([](ota_error_t error) {
    Serial.printf("Error[%u]: ", error);
    if (error == OTA_AUTH_ERROR) Serial.println("Auth Failed");
    else if (error == OTA_BEGIN_ERROR) Serial.println("Begin Failed");
    else if (error == OTA_CONNECT_ERROR) Serial.println("Connect Failed");
    else if (error == OTA_RECEIVE_ERROR) Serial.println("Receive Failed");
    else if (error == OTA_END_ERROR) Serial.println("End Failed");
  });
  ArduinoOTA.begin();
  
  pinMode(led, OUTPUT);
  pinMode(led1, OUTPUT);
  digitalWrite(led, 0);
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  Serial.println("");

  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  if (MDNS.begin("esp8266")) {
    Serial.println("MDNS responder started");
  }

  server.on("/", handleRoot);
  server.on("/help", helping);
  server.on("/ondviz", Yesdviz);
  server.on("/offdviz", Nodviz);
  server.on("/dat1", Dat1);
  server.on("/dat2", Dat2);
  server.on("/dat3", Dat3);
  server.on("/meteo", metiost);
  server.on("/datsiki", datk);
  server.on("/setof", svetor);
  server.on("/onspec", specon);
  server.on("/offspec", specoff);

  server.on("/inline", [](){
    server.send(200, "text/html", "this works as well");
    digitalWrite(led1, 1);
  });

  server.onNotFound(handleNotFound);

  server.begin();
  Serial.println("HTTP server started");
}

void loop(void){
  server.handleClient();
  ArduinoOTA.handle();
}
