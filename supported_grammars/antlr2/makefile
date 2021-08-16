# Generated code from trgen 0.8.7
GENERATED = ANTLRv2Lexer.cs ANTLRv2Parser.cs 
default:
	dotnet restore
	dotnet build
run:
	trwdog dotnet run $(RUNARGS)
clean:
	dotnet clean
	rm -rf bin obj
test:
	bash test.sh
