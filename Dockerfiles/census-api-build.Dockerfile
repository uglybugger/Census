FROM microsoft/dotnet:2.1-sdk AS build
ARG BUILD_NUMBER=0.0.0

WORKDIR /src
COPY . .

# Build and pack the packages separately. `nuget pack` is finnicky.
RUN dotnet build -c Release
RUN dotnet pack Census.Client -c Release -o out --include-symbols --no-build -p:PackageVersion=${BUILD_NUMBER}

# Publish the Web API app separately. Thanks, NuGet.
RUN dotnet publish Census.Api/Census.Api.csproj -c Release -o out