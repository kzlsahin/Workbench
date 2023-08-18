@echo off
Echo activating python env..
start called.bat
set ps_fn=ofd.ps1
echo [System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms") ^| out-null > %ps_fn%
echo $OpenFileDialog = New-Object System.Windows.Forms.OpenFileDialog >> %ps_fn%
echo $OpenFileDialog.initialDirectory = "%USERPROFILE%\Downloads" >> %ps_fn%
echo $OpenFileDialog.filter = "Excel workbooks (*.xlsx)|*.xlsx|All files (*.*)|*.*" >> %ps_fn%
echo $OpenFileDialog.ShowDialog() >> %ps_fn%
echo $OpenFileDialog.filename >> %ps_fn%
 
for /F "tokens=* usebackq" %%a in (`powershell -executionpolicy bypass -file %ps_fn%`) do if not "%%a" == "Cancel" if not "%%a" == "OK" set filename=%%a
del %ps_fn%
 
if not "%filename%"=="" echo %filename%
