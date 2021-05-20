
build:
	dotnet restore
	dotnet build
	nuget pack base.nuspec
	nuget pack base.nuspec -Symbols -SymbolPackageFormat snupkg
