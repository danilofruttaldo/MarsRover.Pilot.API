dotnet tool update --global dotnet-ef

$name = Read-Host 'Migration Name'
$contextName = "RoverContext"
$projectPath = "$PSScriptRoot\..\src\MarsRover.Pilot.API.Infrastructure\MarsRover.Pilot.API.Infrastructure.csproj"
$startupProjectPath = "$PSScriptRoot\..\src\MarsRover.Pilot.API\MarsRover.Pilot.API.csproj"

dotnet ef migrations add $name -c $contextName -p $projectPath -s $startupProjectPath