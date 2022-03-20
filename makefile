
build:
	dotnet restore
	dotnet build
	nuget pack base.nuspec
	nuget pack base.nuspec -Symbols -SymbolPackageFormat snupkg

setup:
	dotnet nuget add source $cwd/ --name nuget-base

publish:
	dotnet nuget push Domemtech.TrashBase.3.4.0.nupkg --api-key ${trashkey} --source https://api.nuget.org/v3/index.json

clean:
	rm -rf */obj */bin
	rm -rf ${USERPROFILE}/.nuget/packages/Domemtech.TrashBase
	rm -f *.nupkg *.snupkg
	rm -rf nuget.config
	dotnet nuget remove source nuget-base 2>&1 > /dev/null
