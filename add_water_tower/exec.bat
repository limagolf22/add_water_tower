@echo off
cd ./scripts & script.exe
cd ../fspackagetool & fspackagetool.exe ../water_tower_package/Project-add-water-tower.xml -outputdir ../water_tower_package
cd ../
cd ../
copy %CD%\add_water_tower\water_tower_package\Packages\add-water-tower\scenery\water_tower.bgl %CD%\water_tower_scenery\scenery\
exit