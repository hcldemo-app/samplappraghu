FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["GICDashboardMicroservices/GICDashboardMicroservices.csproj", "GICDashboardMicroservices/"]
RUN dotnet restore "GICDashboardMicroservices/GICDashboardMicroservices.csproj"
COPY . .
WORKDIR "/src/GICDashboardMicroservices"
RUN dotnet build "GICDashboardMicroservices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GICDashboardMicroservices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GICDashboardMicroservices.dll"]