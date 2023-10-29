FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Usar la imagen SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./","DigitalBookstore.WebApi/"]
RUN dotnet restore "DigitalBookstore.WebApi/DigitalBookstore.WebApi.csproj"
COPY . .
WORKDIR "/src/DigitalBookstore.WebApi"
RUN dotnet build "DigitalBookstore.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBookstore.WebApi.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBookstore.WebApi.dll"]
