#!/bin/bash

sudo python /home/pi/Scripts/GPIO_Master.py &
sudo python /home/pi/Scripts/Backlight_Toggle.py &
sudo python /home/pi/Scripts/Start_Non_GPS_Scan.py &