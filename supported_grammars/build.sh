#!/bin/sh

#for i in abnf antlr2 antlr3 antlr4 bison cocor iso14977 javacc jison lark lbnf pegen pegjs pest rex sablecc w3cebnf xtext
# iso14977
for i in javacc jison lark lbnf pegen pegjs pest rex sablecc w3cebnf xtext
do
    cd $i
	rm -rf Generated
    if [ -f "pom.xml" ]
    then
        trgen --template-sources-directory ../templates
		dotnet build Generated/*.csproj
    else
        echo "No pom.xml in $i"
    fi
    cd ..
done
