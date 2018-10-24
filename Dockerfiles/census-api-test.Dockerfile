FROM census-api-build:latest AS build
FROM build AS test
WORKDIR /src
ENTRYPOINT ["dotnet", "test"]