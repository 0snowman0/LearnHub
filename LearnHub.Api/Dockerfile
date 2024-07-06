#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LearnHub.Api/LearnHub.Api.csproj", "LearnHub.Api/"]
COPY ["LearnHub.Email/LearnHub.Email.csproj", "LearnHub.Email/"]
COPY ["LearnHub.File/LearnHub.File.csproj", "LearnHub.File/"]
COPY ["LearnHub.Persistence/LearnHub.Persistence.csproj", "LearnHub.Persistence/"]
COPY ["LearnHub.Application/LearnHub.Application.csproj", "LearnHub.Application/"]
COPY ["LearnHub.Domain/LearnHub.Domain.csproj", "LearnHub.Domain/"]
COPY ["LearnHub.Identity/LearnHub.Identity.csproj", "LearnHub.Identity/"]
COPY ["LearnHub.SMS/LearnHub.SMS.csproj", "LearnHub.SMS/"]
RUN dotnet restore "./LearnHub.Api/LearnHub.Api.csproj"
COPY . .
WORKDIR "/src/LearnHub.Api"
RUN dotnet build "./LearnHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LearnHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnHub.Api.dll"]