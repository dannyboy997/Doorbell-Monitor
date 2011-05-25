; Robot Engine Installer
;
; 
;--------------------------------

; The name of the installer
Name "Doorbell Monitor Server Setup"

; The file to write
OutFile "Doorbell Server Setup.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Doorbell Monitor\Server\"
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
  File "Doorbell Server.exe"
  File "inpout32.dll"
  File "icon.ico"
  File "clientlist.conf"

  # define uninstaller name
  writeUninstaller $INSTDIR\uninstall.exe

  # create a shortcut named "new shortcut" in the start menu programs directory
  # point the new shortcut at the program uninstaller
  CreateDirectory "$SMPROGRAMS\Doorbell Monitor\Server"
  createShortCut "$SMPROGRAMS\Doorbell Monitor\Server\Doorbell Monitor Server.lnk" "$INSTDIR\Doorbell Server.exe"
  createShortCut "$SMPROGRAMS\Doorbell Monitor\Server\Unistall.lnk" "$INSTDIR\uninstall.exe"
  CreateShortCut "$DESKTOP\Doorbell Monitor Server.lnk" "$INSTDIR\Doorbell Server.exe"

  
SectionEnd ; end the section

# create a section to define what the uninstaller does.
# the section will always be named "Uninstall"
section "Uninstall"
 
# Always delete uninstaller first
delete $INSTDIR\uninstaller.exe
 
# now delete installed file
  delete "$INSTDIR\Doorbell Server.exe"
  delete "$INSTDIR\inpout32.dll"
  delete "$INSTDIR\icon.ico"
  delete "$INSTDIR\uninstall.exe"
 
  delete $INSTDIR
 
  # second, remove the link from the start menu
  delete "$SMPROGRAMS\Doorbell Monitor\Server\Doorbell Monitor Server.lnk"
  delete "$SMPROGRAMS\Doorbell Monitor\Server\Unistall.lnk"
  delete "$SMPROGRAMS\Doorbell Monitor\Server"
  delete "$DESKTOP\Doorbell Monitor Server.lnk"


sectionEnd