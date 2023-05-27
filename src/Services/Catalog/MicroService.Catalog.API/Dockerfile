FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Catalog/MicroService.Catalog.API/MicroService.Catalog.API.csproj", "Services/Catalog/MicroService.Catalog.API/"]
RUN dotnet restore "Services/Catalog/MicroService.Catalog.API/MicroService.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/MicroService.Catalog.API"
RUN dotnet build "MicroService.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Catalog.API.csproj" -c Release -o /app/publish #/p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Catalog.API.dll"]
