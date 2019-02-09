# SCADA GUIDELINE

This guideline helps you to understand the SCADA system. You are going to find out the features of the system and how they pretend to work. This SCADA system was inspired by the real live SCADA systems and the SCADA interface design principles.

**Introduction to Main Page:**

![Image of Main Page](https://i.imgur.com/RBus3be.png)

*Figure 1: Main page of the SCADA system.*

Power Button: To start the SCADA system, turn the power button on. It doesn’t allow to turn off the system because of using the time session. The user can’t stop the system immediately. It causes a damage to the system. This is a protection for the system. The best thing to turn off the system is closing the window of the software and killing the all tasks immediately.

Information button: It opens the information page. Information page gives an information about the designer.

![Image of Info](https://i.imgur.com/KeND2iy.png)

*Figure 2: Information Page*

Valve Monitoring: It shows the status of the valves.

![Image of Valve Monitoring](https://i.imgur.com/kYInBxv.png)

*Figure 3: Valve Monitoring Page*

**Alarm Signal:** Alarm signal starts working when the oxygen tanks are full or empty. Additionally, alarm voice notifies the user when the oxygen tanks are full or empty. The only way to turn off the alarm signal and the voice is opening or closing the valve. 

This SCADA system uses flash mimics for getting notified the user if the oxygen tank is full or empty.

**Oxygen Tank:** It shows the status of the oxygen tank. There are 3 different color changes for the oxygen tank. These color changes help the user to understand the ratio of the capacity of the oxygen tank.

•	If the percentage of the oxygen tank is 25 or lower, red color appears on the tank.
•	If the percentage of the oxygen tank is 50, yellow color appears on the tank.
•	If the percentage of the oxygen tank is 75 or higher, blue color appears on the tanks.

![Image of Color Changes](https://i.imgur.com/y0MFfr1.png)

*Figure 4: Color changes in the oxygen tank.*

**Valve:** It helps to control the oxygen tanks. If the valve is open, it starts filling the oxygen tank. The valve does not work when it is closed. Oxygen tank starts bleeding when the valve is closed.

The user cannot control the valve in these conditions:
•	While the oxygen tank is getting filled.
•	If the valve is not necessarily needed to be open because it is already full.

**Pressure Gauge:** It shows the pressure in the oxygen tank.

![Image of Pressure Changes](https://i.imgur.com/y0MFfr1.png)

*Figure 5: Pressure changes in the oxygen tank.*

**Data List:** It gives an information for the status of the oxygen tank. The user gets notified with this data list. Data list shows the date, information about the status of the oxygen tank, and the priority of the information.

**Understanding the colors in the data list row: **

•	Red color on the row shows the high priority.
•	Yellow color on the row shows the low priority.
•	Green color on the row shows the normal priority.

![Image of Main Page](https://i.imgur.com/RBus3be.png)

*Figure 6:Data List*

**Checklist of the Mimic Design:**

![Image of Mimic Design 1](https://i.imgur.com/UsiVvyD.png)
![Image of Mimic Design 2](https://i.imgur.com/JEJQ0A3.png)

This checklist shows that how many mimic designs inspired my design from the SCADA Mimic Design Principles.

## Mimic Design Score: 10/16

# Note: 
This project was made for the UI Design Principles class.
