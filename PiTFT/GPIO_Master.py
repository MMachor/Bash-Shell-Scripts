#!/usr/bin/env python3
from gpiozero import Button
from signal import pause
import os, sys

offGPIO = int(sys.argv[1]) if len(sys.argv) >= 2 else 17
holdTime = int(sys.argv[2]) if len(sys.argv) >= 3 else 6

def shutdown():
    os.system("bash /home/pi/Scripts/Backlight_Off.sh")
    os.system("sudo poweroff")
   
btn = Button(offGPIO, hold_time=holdTime)
btn.when_held = shutdown

pause()