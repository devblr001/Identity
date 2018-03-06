//msbuild "NorthwindDB.sqlproj" /p:Configuration=Release /p:Platform="Any CPU"
//"C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:dbDacFx="NorthwindDB.dacpac" -dest:dbDacFx="...",dacpacAction=Deploy,CreateNewDatabase=True'

msbuild /t:Publish /p:SqlPublishProfilePath="NorthwindDB.publish.xml" NorthwindDB.sqlproj
set /p DUMMY=Hit ENTER to continue...