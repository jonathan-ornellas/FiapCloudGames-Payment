# =========================
# 🔹 BUILD + PUBLISH
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o repositório
COPY . .

# Restaura dependências pela solution
RUN dotnet restore ./FiapCloudGames.Payments.sln

# Publica a API
RUN dotnet publish ./src/FiapCloudGames.Payments.Api/FiapCloudGames.Payments.Api.csproj \
    -c Release -o /app/publish /p:UseAppHost=false

# =========================
# 🔹 RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Docker

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "FiapCloudGames.Payments.Api.dll"]
