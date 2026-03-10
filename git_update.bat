@ECHO OFF
git config --global user.name "Muhammed Al-Ansari"
git config --global user.email "medmrt@gmail.com"
git add .
set /p commit=Enter commit text: 
git commit -m "%commit%"
git push
Pause