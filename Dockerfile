# ── Build stage ───────────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["BookVerse.Api/BookVerse.Api.csproj",                         "BookVerse.Api/"]
COPY ["BookVerse.Application/BookVerse.Application.csproj",         "BookVerse.Application/"]
COPY ["BookVerse.Core/BookVerse.Core.csproj",                       "BookVerse.Core/"]
COPY ["BookVerse.Infrastructure/BookVerse.Infrastructure.csproj",   "BookVerse.Infrastructure/"]

RUN dotnet restore "BookVerse.Api/BookVerse.Api.csproj"

COPY . .
WORKDIR "/src/BookVerse.Api"
RUN dotnet build "BookVerse.Api.csproj" -c Release -o /app/build --no-restore

# ── Publish stage ─────────────────────────────────────────────────────────────
FROM build AS publish
RUN dotnet publish "BookVerse.Api.csproj" -c Release -o /app/publish \
    --no-restore /p:UseAppHost=false

# ── Runtime stage ─────────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "BookVerse.Api.dll"]