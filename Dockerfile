# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy solution file and project files for restore
COPY MyStore_backend.sln .
COPY MyStore_backend/*.csproj ./MyStore_backend/

# Use --force and --no-cache to avoid Windows-specific cache issues
RUN dotnet restore --force --no-cache

# copy everything else and build the web application
COPY MyStore_backend/. ./MyStore_backend/
WORKDIR /source/MyStore_backend

# Build and publish in one step
RUN dotnet publish -c Release -o /app --force

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

# Copy the SQLite database files to the app directory
COPY MyStore_backend/MyStoreProducts.db ./
COPY MyStore_backend/MyStoreAuth.db ./

ENTRYPOINT ["dotnet", "MyStore_backend.dll"]