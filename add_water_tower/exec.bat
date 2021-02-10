@echo off
cd ./scripts & script.exe
cd ../fspackagetool & fspackagetool.exe ../water_tower_package/MyProject.xml -outputdir ../water_tower_package
cd ../
cd ../
copy %CD%\bin\water_tower_package\Packages\test-test\scenery\water_tower.bgl %CD%\test-test\scenery\
pause