FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ModelGen.Api/ModelGen.Api.csproj", "ModelGen.Api/"]
COPY ["ModelGen.Application/ModelGen.Application.csproj", "ModelGen.Application/"]
COPY ["ModelGen.Domain/ModelGen.Domain.csproj", "ModelGen.Domain/"]
COPY ["ModelGen.Shared/ModelGen.Shared.csproj", "ModelGen.Shared/"]
COPY ["ModelGen.Infrastructure/ModelGen.Infrastructure.csproj", "ModelGen.Infrastructure/"]
RUN dotnet restore "ModelGen.Api/ModelGen.Api.csproj"
COPY . .
WORKDIR "/src/ModelGen.Api"
RUN dotnet build "ModelGen.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ModelGen.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModelGen.Api.dll"]
