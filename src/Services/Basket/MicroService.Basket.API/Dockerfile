FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/MicroService.Basket.API/MicroService.Basket.API.csproj", "Services/Basket/MicroService.Basket.API/"]
RUN dotnet restore "Services/Basket/MicroService.Basket.API/MicroService.Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/MicroService.Basket.API"
RUN dotnet build "MicroService.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Basket.API.dll"]
