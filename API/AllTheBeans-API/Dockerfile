# /API/AllTheBeans-API/Dockerfile

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies separately for better caching
COPY ["AllTheBeans-API.csproj", "."]
RUN dotnet restore "./AllTheBeans-API.csproj"

# Copy the rest of the application's source code
COPY . .

# Run the build command from the /src directory
# The project file is in the current directory, so we just reference it by name.
RUN dotnet build "AllTheBeans-API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
# The working directory is still /src from the previous stage
RUN dotnet publish "AllTheBeans-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllTheBeans-API.dll"]