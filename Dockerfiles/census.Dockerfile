FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# FROM build AS test
# WORKDIR /src
# RUN dotnet test

FROM base AS final
WORKDIR /app
COPY --from=build /src/Census.Api/out .
ENTRYPOINT ["dotnet", "Census.Api.dll"]