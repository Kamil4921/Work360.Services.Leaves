FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Work360.Services.Leaves.Api/Work360.Services.Leaves.Api.csproj", "src/Work360.Services.Leaves.Api/"]
RUN dotnet restore "src/Work360.Services.Leaves.Api/Work360.Services.Leaves.Api.csproj"
COPY . .
WORKDIR "src/Work360.Services.Leaves.Api"
RUN dotnet build "Work360.Services.Leaves.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Work360.Services.Leaves.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Work360.Services.Leaves.Api.dll"]