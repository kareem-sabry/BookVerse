FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BookVerseApi.sln ./

# 🔥 IMPORTANT: keep real folder structure
COPY src/ ./src/
COPY tests/ ./tests/

RUN dotnet restore BookVerseApi.sln

WORKDIR /src/src/BookVerse.Api
RUN dotnet build BookVerse.Api.csproj -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish BookVerse.Api.csproj -c Release -o /app/publish \
    --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "BookVerse.Api.dll"]