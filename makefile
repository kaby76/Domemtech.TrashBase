
build:
	dotnet restore
	dotnet build
	nuget pack base.nuspec
	nuget pack base.nuspec -Symbols -SymbolPackageFormat snupkg

publish:
	dotnet nuget push Domemtech.TrashBase.1.5.0.nupkg --api-key ${trashkey} --source https://api.nuget.org/v3/index.json

clean:
	rm -rf */obj */bin
	rm -rf ${USERPROFILE}/.nuget/packages/Domemtech.TrashBase
	rm -f *.nupkg *.snupkg

