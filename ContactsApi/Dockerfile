FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Render necesita que el contenedor escuche en el puerto 10000
EXPOSE 10000
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ContactsApi/ContactsApi.csproj", "ContactsApi/"]
RUN dotnet restore "./ContactsApi/ContactsApi.csproj"
COPY . .
WORKDIR "/src/ContactsApi"
RUN dotnet build "./ContactsApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ContactsApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactsApi.dll"]
