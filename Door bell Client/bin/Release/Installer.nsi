; Robot Engine Installer
;
; 
;--------------------------------

; The name of the installer
Name "Doorbell Monitor Client Setup"

; The file to write
OutFile "Doorbell Client Setup.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Doorbell Monitor\Client\"
; Request application privileges for Windows Vista
RequestExecutionLevel user

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Doorbell Client.exe"
  File "icon.ico"
  File "chimes.wav"

  # define uninstaller name
  writeUninstaller $INSTDIR\uninstall.exe

  # create a shortcut named "new shortcut" in the start menu programs directory
  # point the new shortcut at the program uninstaller
  CreateDirectory "$SMPROGRAMS\Doorbell Monitor\Client"
  createShortCut "$SMPROGRAMS\Doorbell Monitor\Client\Doorbell Monitor Client.lnk" "$INSTDIR\Doorbell Client.exe"
  createShortCut "$SMPROGRAMS\Doorbell Monitor\Client\Unistall.lnk" "$INSTDIR\uninstall.exe"
  CreateShortCut "$DESKTOP\Doorbell Monitor Client.lnk" "$INSTDIR\Doorbell Client.exe"

  
SectionEnd ; end the section

# create a section to define what the uninstaller does.
# the section will always be named "Uninstall"
section "Uninstall"
 
# Always delete uninstaller first
delete $INSTDIR\uninstaller.exe
 
# now delete installed file
  delete "$INSTDIR\Doorbell Client.exe"
  delete "$INSTDIR\icon.ico"
  delete "$INSTDIR\chimes.wav"
  delete "$INSTDIR\uninstall.exe"
 
  delete $INSTDIR
 
  # second, remove the link from the start menu
  delete "$SMPROGRAMS\Doorbell Monitor\Client\Doorbell Monitor Client.lnk"
  delete "$SMPROGRAMS\Doorbell Monitor\Client\Unistall.lnk"
  delete "$SMPROGRAMS\Doorbell Monitor\Client"
  delete "$DESKTOP\Doorbell Monitor Client.lnk"


sectionEnd