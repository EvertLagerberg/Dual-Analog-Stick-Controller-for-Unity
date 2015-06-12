
//LeftStick Horizontal
int LxPin = A1;
//Leftstick Vertical
int LyPin = A0;
//LeftStick Button
int LbuttonPin = 2;

//LeftStick Position variables
int LxPosition = 0;
int LyPosition = 0;
int LbuttonState = 0;


//RightStick Horizontal
int RxPin = A3;
//RightStick Vertical
int RyPin = A2;
//RightStick Button
int RbuttonPin = 4;

//RightStick Position variables
int RxPosition = 0;
int RyPosition = 0;
int RbuttonState = 0;


int x0;
int y0;

void setup() {
  // initialize serial communications at 9600 bps:
  Serial.begin(9600); 
  
  //LeftStick
  
  pinMode(LxPin, INPUT);
  pinMode(LyPin, INPUT);
  //activate pull-up resistor on the push-button pin
  pinMode(LbuttonPin, INPUT_PULLUP); 
  
  //RightStick
  
  pinMode(RxPin, INPUT);
  pinMode(RyPin,INPUT);
  //activate pull-up resistor on the push-button pin
  pinMode(RbuttonPin, INPUT_PULLUP); 
  
  // For versions prior to Arduino 1.0.1
  // pinMode(buttonPin, INPUT);
  // digitalWrite(buttonPin, HIGH);
  
  x0 = 510;
  y0 = 510;
}

void loop() {
  //LeftStick
  LxPosition = (analogRead(LxPin)-x0)*-1;
  LyPosition = analogRead(LyPin)-y0;
  LbuttonState = digitalRead(LbuttonPin);
  
  //RightStick
  RxPosition = (analogRead(RxPin)-x0)*-1;
  RyPosition = analogRead(RyPin)-y0;
  RbuttonState = digitalRead(RbuttonPin);
  
  
  
  //Print to Serial port
  Serial.print(LxPosition);
  Serial.print(",");
  Serial.print(LyPosition);
  Serial.print(",");
  Serial.print(LbuttonState);
  Serial.print(",");
  Serial.print(RxPosition);
  Serial.print(",");
  Serial.print(RyPosition);
  Serial.print(",");
  Serial.println(RbuttonState);

  delay(4); // add some delay between reads
}
