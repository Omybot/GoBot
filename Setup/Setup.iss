; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "GoBot"
#define MyAppVersion "1.16.0"
#define MyAppPublisher "Omybot"
#define MyAppURL "www.omybot.com"
#define MyAppExeName "GoBot.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9B3BA649-FE71-475C-90F8-981BDC21C1C4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=.
OutputBaseFilename=SetupGoBot
SetupIconFile=iconeSetup.ico
Compression=lzma
SolidCompression=yes
WizardSmallImageFile=RobotSmall.bmp
WizardImageFile=Robot.bmp

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Files]                                                                                          
Source: "..\GoBot\GoBot\bin\Release\GoBot.exe"; DestDir: "{app}"; Flags: ignoreversion  
Source: "..\GoBot\GoBot\bin\Release\Composants.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./iconeTlog.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "./iconeElog.ico"; DestDir: "{app}"; Flags: ignoreversion    
Source: "./DShowNET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./Bytecode.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./Sequencer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./UsbWrapper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./Usc.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "./Jokerman.TTF"; DestDir: "{fonts}"; FontInstall: "Jokerman"; Flags: onlyifdoesntexist uninsneveruninstall  
;Source: "C:\Users\Kryss\AppData\Local\GoBot\graphGros.bin"; DestDir: "{localappdata}\GoBot"; Flags: ignoreversion
;Source: "C:\Users\Kryss\AppData\Local\GoBot\graphPetit.bin"; DestDir: "{localappdata}\GoBot"; Flags: ignoreversion    
Source: "C:\Users\Christopher\AppData\Local\GoBot\config.xml"; DestDir: "{localappdata}\GoBot"; Flags: ignoreversion  

; NOTE: Don't use "Flags: ignoreversion" on any shared system files     
          
[Registry]  
Root: HKCR; Subkey: ".tlog"; ValueType: string; ValueName: ""; ValueData: "Fichier archivage trames"; Flags: uninsdeletevalue
Root: HKCR; Subkey: "Fichier archivage trames"; ValueType: string; ValueName: ""; ValueData: "GoBot"; Flags: uninsdeletekey
Root: HKCR; Subkey: "Fichier archivage trames\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\iconeTlog.ico"
Root: HKCR; Subkey: "Fichier archivage trames\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\GoBot.exe"" ""%1"""

Root: HKCR; Subkey: ".elog"; ValueType: string; ValueName: ""; ValueData: "Fichier archivage events"; Flags: uninsdeletevalue
Root: HKCR; Subkey: "Fichier archivage events"; ValueType: string; ValueName: ""; ValueData: "GoBot"; Flags: uninsdeletekey
Root: HKCR; Subkey: "Fichier archivage events\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\iconeElog.ico"
Root: HKCR; Subkey: "Fichier archivage events\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\GoBot.exe"" ""%1"""
                                                                                                                              
Root: HKCU; Subkey: "Software\GoBot"; ValueType: string; ValueName: "Path"; ValueData: "{localappdata}\GoBot"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall

