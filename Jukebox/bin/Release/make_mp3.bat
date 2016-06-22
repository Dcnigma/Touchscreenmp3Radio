ECHO OFF
cd/
cls
ECHO Looking for Mp3's Please Wait!
ECHO OFF
c:
md Jukebox
dir.exe C:\Users\Dcnigma\*.mp3 /s /b > c:\Jukebox\mp3list.txt
exit