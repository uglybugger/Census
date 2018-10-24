FROM microsoft/dotnet:2.1-sdk AS build
ARG BUILD_NUMBER=0.0.0

WORKDIR /src
COPY src .

# Build and pack the packages separately. `nuget pack` is finnicky.
RUN dotnet build -p:Version=${BUILD_NUMBER} -c Release
RUN dotnet pack Census.Client -c Release -o out --include-symbols --no-build -p:Version=${BUILD_NUMBER} -p:PackageVersion=${BUILD_NUMBER}

# Publish the Web API app separately. Thanks, NuGet.
RUN dotnet publish Census.Api/Census.Api.csproj -p:Version=${BUILD_NUMBER} -c Release -o out