FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EXE201.SmartThrive.API/EXE201.SmartThrive.API.csproj", "EXE201.SmartThrive.API/"]
COPY ["EXE201.SmartThrive.Data/EXE201.SmartThrive.Data.csproj", "EXE201.SmartThrive.Data/"]
COPY ["EXE201.SmartThrive.Domain/EXE201.SmartThrive.Domain.csproj", "EXE201.SmartThrive.Domain/"]
COPY ["EXE201.SmartThrive.Repositories/EXE201.SmartThrive.Repositories.csproj", "EXE201.SmartThrive.Repositories/"]
COPY ["EXE201.SmartThrive.Services/EXE201.SmartThrive.Services.csproj", "EXE201.SmartThrive.Services/"]
RUN dotnet restore "EXE201.SmartThrive.API/EXE201.SmartThrive.API.csproj"
COPY . .
WORKDIR "/src/EXE201.SmartThrive.API"
RUN dotnet build "EXE201.SmartThrive.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EXE201.SmartThrive.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EXE201.SmartThrive.API.dll"]

