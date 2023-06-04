FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Ordering/MicroService.Ordering.API/MicroService.Ordering.API.csproj", "Services/Ordering/MicroService.Ordering.API/"]
COPY ["Services/Ordering/MicroService.Ordering.Application/MicroService.Ordering.Application.csproj", "Services/Ordering/MicroService.Ordering.Application/"]
COPY ["Services/Ordering/MicroService.Ordering.Domain/MicroService.Ordering.Domain.csproj", "Services/Ordering/MicroService.Ordering.Domain/"]
COPY ["Services/Ordering/MicroService.Ordering.Infrastructure/MicroService.Ordering.Infrastructure.csproj", "Services/Ordering/MicroService.Ordering.Infrastructure/"]
RUN dotnet restore "Services/Ordering/MicroService.Ordering.API/MicroService.Ordering.API.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/MicroService.Ordering.API"
RUN dotnet build "MicroService.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Ordering.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Ordering.API.dll"]
