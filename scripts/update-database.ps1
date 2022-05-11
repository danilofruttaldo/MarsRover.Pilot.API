dotnet tool update --global dotnet-ef

$projectPath = "$PSScriptRoot\..\src\MarsRover.Pilot.API\MarsRover.Pilot.API.csproj"

dotnet ef database update -p $projectPath