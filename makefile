export DB_USER := mapuser
export DB_PASSWORD := MapProgram!

all:
	cd console/; dotnet run
build:
	cd maplib/; dotnet build; cd ../console/; dotnet build
test:
	cd test; dotnet test

.PHONY: all build test
