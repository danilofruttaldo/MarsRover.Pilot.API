dotnet tool update --global dotnet-ef

$name = Read-Host 'Migration Name'
$projectPath = "$PSScriptRoot\..\src\MarsRover.Pilot.API\MarsRover.Pilot.API.csproj"

dotnet ef database update $name -p $projectPath