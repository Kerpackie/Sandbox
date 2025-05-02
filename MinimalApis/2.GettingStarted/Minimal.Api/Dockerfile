FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MinimalApis/2.GettingStarted/Minimal.Api/Minimal.Api.csproj", "MinimalApis/2.GettingStarted/Minimal.Api/"]
RUN dotnet restore "MinimalApis/2.GettingStarted/Minimal.Api/Minimal.Api.csproj"
COPY . .
WORKDIR "/src/MinimalApis/2.GettingStarted/Minimal.Api"
RUN dotnet build "./Minimal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Minimal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Minimal.Api.dll"]
