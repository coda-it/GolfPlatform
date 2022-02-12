DOTNET=dotnet

.PHONY: run
run:
	$(DOTNET) run

.PHONY: run-services
run-services:
	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=DBPassword' -p 1433:1433 mcr.microsoft.com/mssql/server:2017-CU8-ubuntu