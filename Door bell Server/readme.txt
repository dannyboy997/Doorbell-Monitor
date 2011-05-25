******************************* installdir/settings.conf *********************************

<PORT>5530<PORT><LPT1OUT>888<LPT1OUT><LPT1IN>889<LPT1IN>



****************************** installdir/clientlist.conf ********************************

comma separated and terminated ip list
leave blank between commas for localhost (localhost and 127.0.0.1 don't work) 

192.168.1.2,, 192.168.1.2 and localhost

192.168.1.2,  just 192.168.1.2



******************************* installdir/buttons/1.btn *********************************

to add a doorbell just create a file with the next available number(1.btn,2.btn,3.btn,4.btn,5.btn) in the buttons folder

<NAME>Shipping Door<NAME><PORT>1<PORT><PIN>4<PIN><OPEN>1<OPEN><FILETIMEOUT>2<FILETIMEOUT>

<NAME> display name

<PORT> LPT port number (usually 1)

<PIN> LPT pin number (1-5)

<OPEN> Default pin state (pin 1 = 0 pins 2-5 = 1)

<FILETIMEOUT> Seconds to keep the data transfer file 

******************************* installdir/transfer.txt *********************************

contains the button name being pressed for <FILETIMEOUT> seconds