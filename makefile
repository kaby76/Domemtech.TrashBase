
build:
	dotnet restore
	dotnet build
	nuget pack base.nuspec
