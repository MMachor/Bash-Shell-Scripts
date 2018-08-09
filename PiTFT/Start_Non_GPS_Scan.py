#!/usr/bin/env python3
from gpiozero import Button
from signal import pause
import os, sys

scanGPIO = int(sys.argv[1]) if len(sys.argv) >= 2 else 22
holdTime = int(sys.argv[2]) if len(sys.argv) >= 3 else 6

def startScan():
    os.system("bash /home/pi/Scripts/Start_Non_GPS_Scan.sh")
   
btn = Button(scanGPIO, hold_time=holdTime)
btn.when_held = startScan

pause()