$MyInvocation.MyCommand.Path | Split-Path | Push-Location # Run from this script's directory
$Name = (Get-ChildItem *.csproj).BaseName
dotnet build -c Release
mkdir "BepInEx\plugins\$Name"
Copy-Item "bin\Release\netstandard2.1.0\$Name.dll" -Destination "BepInEx\plugins\$Name\"
Compress-Archive -Path ".\BepInEx\plugins\$Name" -DestinationPath "$Name-v.zip"
Remove-Item -Path ".\BepInEx\plugins\$Name" -Recurse
Move-Item -Path "$Name-v.zip" -Destination "C:\Users\Zayne.ZaynesLaptop\OneDrive\Desktop"
