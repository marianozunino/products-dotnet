# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and global.json to the container
COPY ./Products.sln ./global.json ./

# Copy the entire project directory to the container
COPY ./Products.API ./Products.API
COPY ./Products.Business ./Products.Business
COPY ./Products.Common ./Products.Common
COPY ./Products.Backoffice ./Products.Backoffice

# Restore dependencies for the solution
RUN dotnet restore Products.sln

# Build the "Backoffice" project
WORKDIR /app/Products.Backoffice
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image as the final base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/Products.Backoffice/out ./

EXPOSE 80

# Set the entry point for the Backoffice application
ENTRYPOINT ["dotnet", "Products.Backoffice.dll"]
