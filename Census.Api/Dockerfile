FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Census.Api/Census.Api.csproj", "Census.Api/"]
RUN dotnet restore "Census.Api/Census.Api.csproj"
COPY . .
WORKDIR "/src/Census.Api"
RUN dotnet build "Census.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Census.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Census.Api.dll"]