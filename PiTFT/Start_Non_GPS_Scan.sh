#!/bin/bash

checkForFlashDrive="ls /dev | grep sda1"
doesFlashDriveExist=$(eval $checkForFlashDrive)

if [ -n doesFlashDriveExist ] 
then
    sudo mount /dev/sda1 /mnt/Storage/ -o umask=000
else 
    echo "External Flsh Drive not found, please insert and try again."
    exit
fi

checkForWiFiCard="sudo airmon-ng | grep rtl8187 | cut -f 2"
doesWiFiCardExist=$(eval $checkForWiFiCard)

if [ -n doesWiFiCardExist ]
then
    sudo airmon-ng start $doesWiFiCardExist
else
    echo "External Antena not found, please connect antenna and try again."
    exit
fi

scanDate=`date +%m-%d-%Y`
scanTime=`date +%H-%M-%S`

fileName=$scanDate\_$scanTime

checkForWiFiCard="sudo airmon-ng | grep rtl8187 | cut -f 2"
doesWiFiNonitorExist=$(eval $checkForWiFiCard)

if [ -n doesWiFiNonitorExist ]
then
    sudo airodump-ng --beacons --output-format csv -w /mnt/Storage/$fileName $doesWiFiNonitorExist
else
    echo "Monitor Mode not found, please check antenna state and try again."
    exit
fi