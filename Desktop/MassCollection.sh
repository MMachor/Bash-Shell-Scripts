#!/bin/bash

INPUT=/tmp/menu.sh.$$

function updateOUI()
{
	../../usr/MassCollection/scripts/oui.sh
	./Desktop/MassCollection.sh	
}

function startScan()
{
	../../usr/MassCollection/scripts/ScanMenu.sh
}

function mergeGPS()
{
	../../usr/MassCollection/scripts/ParseGPS.sh
}

function importScan()
{
	../../usr/MassCollection/scripts/Import.sh
}

function about()
{
	dialog --backtitle "Mass Collection" --title "About" --msgbox "This utility is designed to collect and catalogue all WiFi Access Points and Clients that are able to be picked up by the attached antena.  This information can then be exported by several different means to be used by various mapping applicaitons.  This will allow Access Points and Clients to be plotted on a map." 15 55
	./Desktop/MassCollection.sh
}

dialog --clear --help-button --backtitle "Command Center" --title "[M A I N - M E N U]" --menu "You can use the UP/DOWN arrow keys, the first \n\
letter of the choice as a hot key, or the \n\
number keys 1-9 to choose an option. \n\
Choose Task" 15 75 4 \
Update_OUI "Updates the oui list to most current" \
Start_Scan "Starts scanning and collecting" \
Merge_GPS "Starts the process of merging GPS info" \
Import_Scan "Starts the process of importing another devices scan" \
About "About this software" \
Exit "Exit to the shell" 2>"${INPUT}"

menuitem=$(<"${INPUT}")

case $menuitem in
	Update_OUI) updateOUI;;
	Start_Scan) startScan;;
	Merge_GPS) mergeGPS;;
	Import_Scan) importScan;;
	About) about;;
	Exit) echo "Bye!";;
esac
