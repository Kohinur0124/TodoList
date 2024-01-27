#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ToDoProject.Api/ToDoProject.Api.csproj", "src/ToDoProject.Api/"]
COPY ["src/ToDoList.Application/ToDoList.Application.csproj", "src/ToDoList.Application/"]
COPY ["src/ToDoProject.Domain/ToDoProject.Domain.csproj", "src/ToDoProject.Domain/"]
COPY ["src/ToDoProject.Infrastructure/ToDoProject.Infrastructure.csproj", "src/ToDoProject.Infrastructure/"]
RUN dotnet restore "./src/ToDoProject.Api/./ToDoProject.Api.csproj"
COPY . .
WORKDIR "/src/src/ToDoProject.Api"
RUN dotnet build "./ToDoProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDoProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoProject.Api.dll"]