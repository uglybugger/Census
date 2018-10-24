FROM census-api-build:latest AS build

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM base AS final
WORKDIR /app
COPY --from=build /src/Census.Api/out .
ENTRYPOINT ["dotnet", "Census.Api.dll"]