#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/HealthChecksDemo/HealthChecksDemo.csproj", "src/HealthChecksDemo/"]
COPY ["src/HealthChecksDemo.Core/HealthChecksDemo.Core.csproj", "src/HealthChecksDemo.Core/"]
COPY ["NuGet.config","NuGet.config"]
RUN dotnet restore "src/HealthChecksDemo/HealthChecksDemo.csproj"
COPY . .
WORKDIR "/src/src/HealthChecksDemo"
RUN dotnet build "HealthChecksDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthChecksDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthChecksDemo.dll"]