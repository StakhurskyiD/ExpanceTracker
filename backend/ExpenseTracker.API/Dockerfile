# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY backend/ExpenseTracker.API/ExpenseTracker.API.csproj ExpenseTracker.API/
RUN dotnet restore ExpenseTracker.API/ExpenseTracker.API.csproj
COPY backend/ExpenseTracker.API/ ExpenseTracker.API/
WORKDIR /src/ExpenseTracker.API
RUN dotnet build ExpenseTracker.API.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ExpenseTracker.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Create the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Set environment variables for ASP.NET Core and MongoDB
ENV ASPNETCORE_URLS=http://+:80
ENV ConnectionStrings__MongoDB=mongodb://mongo:27017
ENTRYPOINT ["dotnet", "ExpenseTracker.API.dll"]