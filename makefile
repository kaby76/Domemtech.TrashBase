
build:
	dotnet restore
	dotnet build
	nuget pack base.nuspec
	nuget pack base.nuspec -Symbols -SymbolPackageFormat snupkg

publish:
	dotnet nuget push Domemtech.TrashBase.$version.nupkg --api-key $trashkey --source https://api.nuget.org/v3/index.json
