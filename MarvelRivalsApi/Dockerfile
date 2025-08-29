# Build Stage (needs SDK)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy remaining files and publish
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage (smaller image)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "MarvelRivalsApi.dll"]