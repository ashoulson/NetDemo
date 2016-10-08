@echo off
REM Automatically migrates DLL files from the VS solution into Unity
REM and generates MDBs. Unity's included PDB2MDB crashes on these DLLs
REM so we use a newer one from Mono itself included in the Util directory.
SET ROOT_PATH=%~dp0
SET ASSEMBLY_PATH=%~dp0.\Unity\Assets\Assemblies\Generated\
SET PROJECT_PATH=%1

ECHO DLL MIGRATION BEGIN 
ECHO Source: %PROJECT_PATH%
ECHO Destination: %ASSEMBLY_PATH%
ECHO Clearing directory...
DEL /Q %ASSEMBLY_PATH%\*
ECHO Copying DLLs...
ECHO f | xcopy "%PROJECT_PATH%*.dll" "%ASSEMBLY_PATH%" /Y
ECHO Copying PDBs...
ECHO f | xcopy "%PROJECT_PATH%*.pdb" "%ASSEMBLY_PATH%" /Y

FOR %%i IN ("%ASSEMBLY_PATH%*.dll") DO (
   IF EXIST "%%~npi.pdb" (
      ECHO Generating MDB for %%i...
	  "%ROOT_PATH%.\Util\pdb2mdb.exe" "%%i"
   )
)
ECHO DLL MIGRATION FINISHED