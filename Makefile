DOTNET=dotnet
NPM=npm
ENV=prod

.DEFAULT_GOAL := all

WEBAPP_MONGO_URI=mongodb://localhost:27017
WEBAPP_MONGO_DB=webapp
WEBAPP_HTTP_PORT=3000

.PHONY: install
install:
	$(DOTNET) restore
	$(NPM) install

.PHONY: all
all:
	$(MAKE) build-frontend

.PHONY: build-frontend
build-frontend:
	$(NPM) rebuild node-sass
	$(NPM) run build:$(ENV)

.PHONY: test
test:
	$(NPM) run test

.PHONY: integration-test
integration-test:
	$(NPM) run cypress:run

.PHONY: lint
lint:
	$(NPM) run tsc
	$(NPM) run lint
	$(NPM) run csslint

.PHONY: fix
fix:
	$(NPM) run prettify
	$(NPM) run lint:fix
	$(NPM) run csslint:fix

.PHONY: run
run:
	$(DOTNET) run

.PHONY: run-services
run-services:
	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=DBPassword' -p 1433:1433 mcr.microsoft.com/mssql/server:2017-CU8-ubuntu