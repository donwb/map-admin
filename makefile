export DB_USER := mapuser
export DB_PASSWORD := MapProgram!

all:
	cd api/; dotnet run
build:
	cd maplib/; dotnet build; cd ../console/; dotnet build; cd ../api; dotnet build
test:
	cd test; dotnet test

console:
	cd console/; dotnet run

.PHONY: all build test console
