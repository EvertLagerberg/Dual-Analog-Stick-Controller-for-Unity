Arduino to Unity Dual Analog Sticks FPS Controller

Hi, this project uses two analog thumbsticks as input. The thumbsticks are connected to an Arduino
which send input data over serial to Unity. In Unity the the data is used in a C#-script to be added
to the First Person Controller as a component.  Below are instructions on how to build you own 
controller and set it up in Unity.

Instructions:

For this project I used the following:

Components:

  Hardware:
  
    - Arduino Uno microprocessor
    - Breadboard and Cables
    - 2 x Analog Thumbsticks + Breakout Boards https://www.sparkfun.com/tutorials/272
  
  Software:
  
    - Arduino IDE 1.0.5
    - Unity 4.6.0f3

  There might be other versions of both hardware and software components that are compatible.

Assembly

  1. Solder each thumbstick to a break out board. [ Instructions ](https://www.sparkfun.com/tutorials/272)
  2. Connect the thumbssticks to the arduino according to [ WireDiagram ](WiringDiagram.png).
  3. Flash the Arduino with the "DoubleAnalogSticksToSerial.ino" sketch in this repository.
  4. In the Arduino IDE, go to "Tools > Serial Monitor". If you have done all the previous steps correctly, 
  you should now be able to see the input values of the thumbsticks that are sent to the serial port.
  
Set up in Unity

  5. Open you scene in Unity and make sure you have a First Person Controller in the scene. 
  6. Import "MoveScript.cs" from this repository to your scene and drag it to your First Person Controller–object. 
  7. Press play to start using your home made controller in Unity!

Thank you!
Evert Lagerberg
[ evert.lagerberg@gmail.com ] (mailto:evert.lagerberg@gmail.com)
