#!/usr/bin/env python3
from gpiozero import Button
from signal import pause
import os, sys

backlightGPIO = int(sys.argv[1]) if len(sys.argv) >= 2 else 27
holdTime = int(sys.argv[2]) if len(sys.argv) >= 3 else 2

backlightOn = True

while True:

    def toggleBacklight():
        global backlightOn

        if(backlightOn == True):
             os.system("bash /home/pi/Scripts/Backlight_Off.sh")
             backlightOn = not backlightOn
        elif (backlightOn == False):
             os.system("bash /home/pi/Scripts/Backlight_On.sh")
             backlightOn = not backlightOn

    btn = Button(backlightGPIO, hold_time=holdTime)
    btn.when_held = toggleBacklight

    pause() 